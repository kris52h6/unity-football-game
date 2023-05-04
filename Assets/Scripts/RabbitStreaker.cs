using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RabbitStreaker : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform startPoint;
    public Transform endPoint;

    private Vector3 target;

    void Start()
    {
        startPoint = GameObject.Find("StreakerStartPoint").transform;
        endPoint = GameObject.Find("StreakerEndPoint").transform;
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }
    
    void UpdateDestination()
    {
        target = endPoint.position;
        agent.SetDestination(target);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
