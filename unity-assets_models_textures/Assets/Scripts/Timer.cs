using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private bool timerActive;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        string MilliString = time.Milliseconds.ToString("D3").Substring(0, 2);
        TimerText.text = time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00") + "." + MilliString;
    }
}
