using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public CameraController CameraController;
    public void OnTriggerEnter(Collider other)
    {
        GoalScored();
    }
    
    public void GoalScored()
    {
        StartCoroutine(CameraController.FollowPlayerCoroutine());
        Debug.Log(SceneManager.GetActiveScene().name);
        GameState.SetLevelCompletedByName(SceneManager.GetActiveScene().name);
        StartCoroutine(LevelCompletedCoroutine());

    }

    public IEnumerator LevelCompletedCoroutine()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");

    }

    
}
