using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    private float timeRemaining = 0;
    private bool timerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {

        {
            if (timerIsRunning)
            {
                if (timeRemaining <= 10.00000)
                {
                    timeRemaining += Time.deltaTime;
                    if (timeRemaining <= 0)
                    {
                        timeRemaining = 0;
                        timerIsRunning = false;
                    }
                    Debug.Log("Time remaining: " + timeRemaining);
                }
                else
                {
                    Debug.Log("Time has game out ! ");
                    timerIsRunning = false;
                }
            }
        }
    }
}
