using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float currentTime;
    public int timeInSeconds = 180;
    public bool isTimeRunning = true;
    public Text timerText;
    void Start()
    {
        currentTime = timeInSeconds; //want the time be 180 seconds 
        UpdateTimer(); //update the time to the current timer 
    }

    void Update()
    {
        if (isTimeRunning)
        {
            currentTime -= Time.deltaTime; //subtract timedelta from currenttime and assign the new amount to current time

            if (currentTime <= 0) //if current time is less than or equal to zero
            {
                currentTime = 0; //current time is zero
                isTimeRunning = false; //time is no more running
                WinCondition(); //appy the win condition for the player 
            }

            UpdateTimer(); //update the timer to the current time
        }
    }

    void UpdateTimer()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60); //we do this to calculate the number of minutes remains currentTime / 60 . We use mathf to always get a whole number
        int seconds = Mathf.FloorToInt(currentTime % 60); //we do this to calculate the number of seconds. We do this by using the module to get the reaming seconds after removing all minutes
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); //we do this to format the time in MM : SS. 
    }

    void WinCondition()
    {
        SceneManager.LoadScene("playerWin", LoadSceneMode.Single);
    }

    //https://chat.openai.com
}
