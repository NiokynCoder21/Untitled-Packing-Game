using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour //invetory count keeper
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

            if (movement != null)
            {
                if (movement.kitchenFood == true)
                {
                    currentKitchenStuff += more;
                    currentItems += points;
                    UpdateScoreText();
                }

                if (movement.livingFood == true)
                {
                    currentLivingStuff += most;
                    currentItems += points;
                    UpdateScoreText();
                }

                if (movement.diningFood == true)
                {
                    currentDiningStuff += better;
                    currentItems += points;
                    UpdateScoreText();
                }
            }

          
        }
    }



    public void LossItems(int points, int more, int most, int better) //the item text when player drop stuff function
    {
        if (currentItems > 0)
        {
            /*if (scoreManager.isKitchen == true)
            {
                if (currentKitchenStuff > 0)
                {
                    currentKitchenStuff -= more;
                    currentItems -= points;
                    UpdateScoreText();
                }
            }*/

       
           /* if (scoreManager.isLivingRoom == true)
            {
                if (currentLivingStuff > 0)
                {
                    currentLivingStuff -= most;
                    currentItems -= points;
                    UpdateScoreText();
                }
                
            }*/


           /* if (scoreManager.isDiningRoom == true)
            {
                if (currentDiningStuff > 0)
                {
                    currentDiningStuff -= better;
                    currentItems -= points;
                    UpdateScoreText();
                }
            }*/

        }
    }

    public void LossKitchenStuff(int points, int more)
    {
        if (scoreManager.isKitchen == true)
        {

            if (movement != null)
            {
                if (movement.selectedKitchen == true)
                {
                    if (currentKitchenStuff > 0)
                    {
                        currentKitchenStuff -= more;
                        currentItems -= points;
                        UpdateScoreText();
                    }
                }
            }
        }
    }

    public void LossDiningStuff(int points, int more)
    {
        if (scoreManager.isDiningRoom == true)
        {            

            if (movement != null)
            {
                if (movement.selectedDining == true)
                {
                    if (currentDiningStuff > 0)
                    {
                        currentDiningStuff -= more;
                        currentItems -= points;
                        UpdateScoreText();
                    }
                }
            }
        }
    }

    public void LossLivingStuff(int points, int more)
    {
        if (scoreManager.isLivingRoom == true)
        {

            if (movement != null)
            {
                if (movement.selectedLiving == true)
                {
                    if (currentLivingStuff > 0)
                    {
                        currentLivingStuff -= more;
                        currentItems -= points;
                        UpdateScoreText();
                    }
                }
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
