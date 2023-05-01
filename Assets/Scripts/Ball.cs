using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 startPosition = new Vector3(-1, 13, -12);
    public Rigidbody body;
    public float kickSpeed = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Player player = other.GetComponent<Player>();
            player.hasBall = true;
            player.ball = this;

        }
    }

    public void Kick(Vector3 kickDirection)
    {
        Debug.Log(kickDirection);
        Vector3 deltaPosition = body.transform.position - kickDirection;

        Vector3 forward = deltaPosition.normalized;
        body.AddForce(forward * kickSpeed, ForceMode.Impulse);

    }

    public void OutOfBounds()
    {
        StartCoroutine(ResetCoroutine());
        
    }

    IEnumerator ResetCoroutine()
    {
        yield return new WaitForSeconds(2);
        transform.position = startPosition; 
    }
    
    
}
