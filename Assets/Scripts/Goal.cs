using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public CameraController CameraController;
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("gol");
        GoalScored();
    }
    
    public void GoalScored()
    {
        StartCoroutine(CameraController.FollowPlayerCoroutine());
        
    }

    
}
