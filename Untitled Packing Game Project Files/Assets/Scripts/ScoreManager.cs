using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;

    public int score;
    public bool isKitchen = false;
    public bool isLivingRoom = false;
    public bool isDiningRoom = false;

    void Start()
    {
        score = 0;
    }

    public void AwardItems(int points)
    {
        score += points;

        if (isKitchen == true)
        {
            score += points;
        }

        if (isLivingRoom == true)
        {
            score += points;
        }

        if (isDiningRoom == true)
        {
            score += points;
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "" + score; //update text to show the current score
    }

    public void SetIsLivingRoom(bool state)
    {
        isLivingRoom = state;
    }

    public void SetIsDiningRoom(bool state)
    {
        isDiningRoom = state;
    }

    public void SetIsKitchen(bool state)
    {
        isKitchen = state;
    }

}
