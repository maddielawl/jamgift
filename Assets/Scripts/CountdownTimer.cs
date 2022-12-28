using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    // The countdown timer text
    public Text timerText;

    // The time in seconds for the countdown timer
    public float countdownTime = 60f;

    // The countdown timer
    private float countdownTimer = 0f;

    void Start()
    {
        // Initialize the countdown timer
        countdownTimer = countdownTime;
    }

    void Update()
    {
        // Decrement the countdown timer
        countdownTimer -= Time.deltaTime;

        // Update the countdown timer text
        timerText.text = countdownTimer.ToString("F2");

        // Check if the countdown timer has reached zero
        if (countdownTimer <= 0f)
        {
            // The countdown has finished
            CountdownFinished();
        }
    }

    void CountdownFinished()
    {
        // You can add any actions you want to perform when the countdown timer finishes here, such as displaying a message or triggering an event.
    }
}