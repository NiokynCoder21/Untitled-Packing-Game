using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOff : MonoBehaviour
{
    public ScoreManager scoreManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KitchenDrop"))
        {
            scoreManager.SetIsKitchen(true);
        }

        if (collision.gameObject.CompareTag("LivingDrop"))
        {
            scoreManager.SetIsLivingRoom(true);
        }

        if (collision.gameObject.CompareTag("DiningDrop"))
        {
            scoreManager.SetIsDiningRoom(true);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KitchenDrop"))
        {
            scoreManager.SetIsKitchen(true);
        }

        if (collision.gameObject.CompareTag("LivingDrop"))
        {
            scoreManager.SetIsLivingRoom(true);
        }

        if (collision.gameObject.CompareTag("DiningDrop"))
        {
            scoreManager.SetIsDiningRoom(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KitchenDrop"))
        {
            scoreManager.SetIsKitchen(false);
        }

        if (collision.gameObject.CompareTag("LivingDrop"))
        {
            scoreManager.SetIsLivingRoom(false);
        }

        if (collision.gameObject.CompareTag("DiningDrop"))
        {
            scoreManager.SetIsDiningRoom(false);
        }
    }
}
