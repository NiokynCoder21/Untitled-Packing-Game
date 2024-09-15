using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public TMP_Text kitchenStuffText;
    public TMP_Text livingStuffText;
    public TMP_Text diningStuffText;

    public int currentKitchenStuff = 0;
    public int currentLivingStuff = 0;
    public int currentDiningStuff = 0;
    public int currentItems = 0;

    public ScoreManager scoreManager;
    public PlayerMovement movement;

    private void Start()
    {
      currentKitchenStuff = 0;
      currentLivingStuff = 0;
      currentDiningStuff = 0;
      currentItems = 0;

      UpdateScoreText(); //display the current score 
    }

 
    public void AwardItems(int points, int more, int most, int better)
    {
        if (currentItems < 5)
        {
            if (movement.isGrocery == true)
            {
                currentKitchenStuff += more;
                currentItems += points;
                UpdateScoreText();
            }

            if (movement.isGrocery == false)
            {
                currentLivingStuff += most;
                currentItems += points;
                UpdateScoreText();
            }

            if (movement.isGrocery == false)
            {
                currentDiningStuff += better;
                currentItems += points;
                UpdateScoreText();
            }
        }
    }

    public void LossItems(int points, int more, int most, int better)
    {
        if (currentItems > 0)
        {
            if (scoreManager.isKitchen == true)
            {
                currentKitchenStuff -= more;
                currentItems -= points;
                UpdateScoreText();
            }

            if (scoreManager.isLivingRoom == true)
            {
                currentLivingStuff -= most;
                currentItems -= points;
                UpdateScoreText();
            }

            if (scoreManager.isDiningRoom == true)
            {
                currentDiningStuff -= better;
                currentItems -= points;
                UpdateScoreText();
            }

            else
            {
                print("dropped something");
            }
        }
    }

    private void UpdateScoreText()
    {
        kitchenStuffText.text = "" + currentKitchenStuff;
        livingStuffText.text = "" + currentLivingStuff;
        diningStuffText.text = "" + currentDiningStuff;
    }
}
