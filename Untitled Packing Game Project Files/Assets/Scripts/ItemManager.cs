using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public TMP_Text currentItemText; //score text

    private int currentItem = 0; //set score to zero

    private void Start()
    {
        currentItem = 0;
        UpdateScoreText(); //display the current score 
    }

 
    public void AwardItems(int points)
    {
        if (currentItem < 5)
        {
            currentItem += points; //add points to score and take the new amount
            UpdateScoreText(); //dispaly the new amount
        }
    }

    public void LossItems(int points)
    {
        if(currentItem <= 5)
        {
            currentItem -= points; //add points to score and take the new amount
            UpdateScoreText(); //dispaly the new amount
        }
    }

    private void UpdateScoreText()
    {
        currentItemText.text = "Grocieries: " + currentItem; //update text to show the current score
    }
}
