using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opponent : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // if layer is ball
        if (collision.gameObject.layer == 9)
        {
            Debug.Log("ball hit opponent");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
