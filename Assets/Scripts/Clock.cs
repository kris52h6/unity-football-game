using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public TMP_Text clockText;

    private float _time;
    void Update()
    {
        _time += Time.deltaTime;
        CalculateTime();
    }

    void CalculateTime()
    {
        float minutes = Mathf.FloorToInt(_time / 60);
        float seconds = Mathf.FloorToInt(_time % 60);
        
        clockText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
