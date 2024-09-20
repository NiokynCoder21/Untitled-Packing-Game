using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float currentTime;
    public int timeInSeconds = 180;
    public bool isTimeRunning = true;
    public TMP_Text timerText;


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
        if (ScoreManager.Instance != null && ScoreManager1.Instance != null)
        {
            // Store the players' scores using PlayerPrefs
            PlayerPrefs.SetInt("Player1Score", ScoreManager.Instance.score);
            PlayerPrefs.SetInt("Player2Score", ScoreManager1.Instance.score);

            // Compare the scores and load the appropriate scene
            if (ScoreManager.Instance.score > ScoreManager1.Instance.score)
            {
                SceneManager.LoadScene("Player1Win", LoadSceneMode.Single); // Load Player 1 win scene
            }

            else if (ScoreManager1.Instance.score > ScoreManager.Instance.score)
            {
                SceneManager.LoadScene("Player2Win", LoadSceneMode.Single); // Load Player 2 win scene
            }

            else
            {
                SceneManager.LoadScene("PlayersDraw", LoadSceneMode.Single); // Load draw scene if scores are equal
            }
        }

    }

}
