using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreakerController : MonoBehaviour
{
    public GameObject prefab;
    public Transform startPosition;
    
    void Update()
    {
        // to generate streakers at random times
        // TODO definitely look to improve this
        int random = Random.Range(0,5000);
        if (random == 1) 
        {
            Instantiate(prefab, startPosition);
        }
    }
}
