using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarStorageManager : MonoBehaviour
{
    public float maxGroceries; //the amount of grocies in the car
    public float currentGroceries; //the amount of grocies left in the car

    public TMP_Text currentGrociesText;

    void Start()
    {
        currentGroceries = maxGroceries;
        UpdateScoreText(); //display the current score 
    }

    public void LossGroceries(int loss)
    {
        if (currentGroceries > 0)
        {
            currentGroceries -= loss;
            UpdateScoreText(); //display the current score 
        }
    }

    private void UpdateScoreText()
    {
        currentGrociesText.text = "" + currentGroceries; //update text to show the current score
    }
}
