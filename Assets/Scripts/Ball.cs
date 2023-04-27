using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody body;
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

    public void Kick(float direction)
    {
        Debug.Log("Shoot!");
        Debug.Log(direction);

        var deltaPosition = body.transform.position;

        var forward = deltaPosition.normalized;
        //var forward = direction.normalized;
        body.AddForce(forward * 20f, ForceMode.Impulse);

    }
}
