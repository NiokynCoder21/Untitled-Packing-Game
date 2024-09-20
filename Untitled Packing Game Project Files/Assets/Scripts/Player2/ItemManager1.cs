using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemManager1 : MonoBehaviour //invetory count keeper
{
    public TMP_Text kitchenStuffText;
    public TMP_Text livingStuffText;
    public TMP_Text diningStuffText;

    public int currentKitchenStuff = 0;
    public int currentLivingStuff = 0;
    public int currentDiningStuff = 0;
    public int currentItems = 0;

    public ScoreManager1 scoreManager;
    public PlayerMovement1 movement;

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
            print("less than 5");

            if (movement != null)
            {
               

                if (movement.kitchenFood == true)
                {
                    currentKitchenStuff += more;
                    currentItems += points;
                    UpdateScoreText();
                    print("more stuff");
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

    public void AddKitchen(int points, int more)
    {
        currentKitchenStuff += more;
        currentItems += points;
        UpdateScoreText();
        print("more stuff");
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

    public void LossDash(int points, int more) //dining
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

    public void LossPush(int points, int more) //living
    {

    }

    public void LossMore(int points, int more) //best ability kitchen
    {

    }

    private void UpdateScoreText()
    {
        kitchenStuffText.text = "" + currentKitchenStuff;
        livingStuffText.text = "" + currentLivingStuff;
        diningStuffText.text = "" + currentDiningStuff;
    }
}
