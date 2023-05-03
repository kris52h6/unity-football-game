using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Goalkeeper : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform[] patrolPoints;

    int patrolIndex;

    private Vector3 target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }
    
    void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            IteratePatrolIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        // sets target patrol point to a random in the patrolpoints list
        int random = Random.Range(0, 3);
        target = patrolPoints[random].position;
        agent.SetDestination(target);
    }

    void IteratePatrolIndex()
    {
        patrolIndex++;
        if (patrolIndex == patrolPoints.Length)
        {
            patrolIndex = 0;
        }
    }
}
