using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 86400;
    public bool timerIsRunning = false;

    public TMP_Text timerText;


    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {     

        TimeSpan t = TimeSpan.FromSeconds(timeRemaining);

        string answer = string.Format("{0:D2}h : {1:D2}m : {2:D2}s",
                        t.Hours,
                        t.Minutes,
                        t.Seconds);

        timerText.text = answer;

    }
}