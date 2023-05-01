using System;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("References")] 
    [Tooltip("The character controller to move")]
    public CharacterController characterController;

    public Animator animator;

    public TMP_Text textField;


    [Header("Move properties")] 
    public float defaultSpeed = 7f;

    public float speed;

    public float sprintSpeed = 20f;

    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;

    private Vector3 _movement = Vector3.zero;

    public bool hasBall = false;
    public Transform ballPosition;
    public Ball ball;

    private float _direction;

    public float respawnTime = 2;
    private Vector3 startPoint;
    private Quaternion startRotation;
    private Quaternion currentPosition;
    private bool dead;
    

    private AudioSource _audioSource;
   
    // Start is called before the first frame update
    void Start()
    {
        startPoint = characterController.gameObject.transform.position;
        startRotation = new Quaternion(0f, 90f, 0f, 0);
        currentPosition = characterController.gameObject.transform.rotation;
        var tmp = characterController.gameObject.transform.GetChild(1).gameObject;
        ballPosition = tmp.transform;
        //ball = gameObject.GetComponent<Ball>();
        _audioSource = GetComponentInChildren<AudioSource>();
    }
    
    
    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Running", false);
        Movement();
        GetBall();
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        
        if (horizontal !=  0 || vertical != 0)
        {
            Vector3 move = new Vector3(horizontal, 0f, vertical).normalized;
            
            animator.SetBool("Running",true);

            _direction = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _direction, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            characterController.Move(move * Time.deltaTime * speed);
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = sprintSpeed;
                animator.SetBool("Sprinting", true);
            }
            else
            {
                speed = defaultSpeed;
                animator.SetBool("Sprinting", false);
            }
        }
        

        if (Input.GetKey(KeyCode.Z))
        {
            if (hasBall)
            {
                KickBall();
            }
        }

        


    }

    void GetBall()
    {
        if (hasBall)
        {
            ball.transform.position = ballPosition.position;
        }
    }

    void KickBall()
    {
        ball.Kick(transform.position);
        hasBall = false;
    }

    public Vector3 Position
    { 
        get => characterController.gameObject.transform.position;
    }

    public float Speed
    {
        get => Mathf.Abs(_movement.x) + Mathf.Abs(_movement.z) / 2;
    }
}