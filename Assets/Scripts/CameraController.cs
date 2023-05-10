using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    private Quaternion _defaultRotation;
    private Vector3 _defaultPosition;
    public AudioSource audioSource;
    private bool _cameraToggle;
    
    public Player player;

    public Ball ball;

    void Start()
    {
        cinemachineVirtualCamera = GameObject.Find("CAM").GetComponent<CinemachineVirtualCamera>();
        _defaultRotation = cinemachineVirtualCamera.transform.rotation;
        _defaultPosition = cinemachineVirtualCamera.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCamera();
        }
    }
    
    public IEnumerator FollowPlayerCoroutine()
    {
        player.animator.SetBool("Goal", true);
        audioSource.Play();
        cinemachineVirtualCamera.LookAt = player.transform;
        cinemachineVirtualCamera.Follow = player.transform;
        cinemachineVirtualCamera.m_Lens.FieldOfView = 20;
        yield return new WaitForSeconds(1);
        cinemachineVirtualCamera.Follow = player.transform;
        cinemachineVirtualCamera.LookAt = null;
        cinemachineVirtualCamera.transform.rotation = _defaultRotation;
        cinemachineVirtualCamera.m_Lens.FieldOfView = 60;
        player.animator.SetBool("Goal", false);
    }

    void ToggleCamera()
    {
        _cameraToggle = (_cameraToggle) ? _cameraToggle = false : _cameraToggle = true;
        if (_cameraToggle)
        {
            cinemachineVirtualCamera.Follow = player.transform;
        }
        else 
        {
             cinemachineVirtualCamera.Follow = ball.transform;
             cinemachineVirtualCamera.transform.position = _defaultPosition;
             cinemachineVirtualCamera.transform.rotation = _defaultRotation;
        }
    }
}
