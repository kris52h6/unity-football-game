using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody body;
    public float kickSpeed = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Player player = other.GetComponent<Player>();
            player.hasBall = true;
            player.ball = this;
            Debug.Log("Has Ball");
            
            //while (player.hasBall)
            //{
            //    gameObject.transform.position = player.ballPosition;
            //}
        }
    }

    public void Kick(Vector3 kickDirection)
    {
        Vector3 deltaPosition = body.transform.position - kickDirection;

        Vector3 forward = deltaPosition.normalized;
        body.AddForce(forward * kickSpeed, ForceMode.Impulse);

    }
}
