using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    private Quaternion _defaultRotation;
    public AudioSource _audioSource;
    
    public Player player;

    public Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        _defaultRotation = cinemachineVirtualCamera.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public IEnumerator FollowPlayerCoroutine()
    {
        player.animator.SetBool("Goal", true);
        _audioSource.Play();
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
}
