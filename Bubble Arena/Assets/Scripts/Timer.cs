using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro; 

public class Timer : MonoBehaviour
{
    private float timeRemaining = 20;
    private bool timerIsRunning = false;
    public TMP_Text textMeshPro;

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
                if (timeRemaining <= 20)
                {
                    timeRemaining-= Time.deltaTime;
                    if (timeRemaining <= 0)
                    {
                        timeRemaining = 0;
                        timerIsRunning = false;
                    }
                    // Debug.Log("Time remaining: " + timeRemaining);
                    textMeshPro.text = "Time remaining : " + (int)timeRemaining + "s";
                }
                else
                {
                    // Debug.Log("Time has game out ! ");
                    textMeshPro.text = "This has game out" + (int)timeRemaining;
                    timerIsRunning = false;
                }
            }

        }
    }
}
