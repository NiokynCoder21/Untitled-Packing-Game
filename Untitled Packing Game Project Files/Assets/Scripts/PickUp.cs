using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public CarStorageManager carManager;
    public ItemManager itemManager;
    public int pickUpAmount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            if (carManager != null && itemManager != null)
            {
                carManager.LossGroceries(pickUpAmount);
                itemManager.AwardItems(pickUpAmount);
            }
        }
    }
}
