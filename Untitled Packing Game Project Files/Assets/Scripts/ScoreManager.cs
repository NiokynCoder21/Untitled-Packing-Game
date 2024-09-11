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
        UpdateScoreText();
    }

    public void AwardItems(int points, int more)
    {
        score += points;
        UpdateScoreText();

        if (isKitchen == true)
        {
            score += more;
            UpdateScoreText();
        }

        if (isLivingRoom == true)
        {
            score += more;
            UpdateScoreText();
        }

        if (isDiningRoom == true)
        {
            score += more;
            UpdateScoreText();
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
