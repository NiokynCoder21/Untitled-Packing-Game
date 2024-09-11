using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOff : MonoBehaviour
{
    public ScoreManager scoreManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KitchenRoom"))
        {
            scoreManager.SetIsKitchen(true);
        }

        if (collision.gameObject.CompareTag("LivingRoom"))
        {
            scoreManager.SetIsLivingRoom(true);
        }

        if (collision.gameObject.CompareTag("DinningRoom"))
        {
            scoreManager.SetIsLivingRoom(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("KitchenRoom"))
        {
            scoreManager.SetIsKitchen(true);
        }

        if (other.gameObject.CompareTag("LivingRoom"))
        {
            scoreManager.SetIsLivingRoom(true);
        }

        if (other.gameObject.CompareTag("DinningRoom"))
        {
            scoreManager.SetIsLivingRoom(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KitchenRoom"))
        {
            scoreManager.SetIsKitchen(false);
        }

        if (collision.gameObject.CompareTag("LivingRoom"))
        {
            scoreManager.SetIsLivingRoom(false);
        }

        if (collision.gameObject.CompareTag("DinningRoom"))
        {
            scoreManager.SetIsLivingRoom(false);
        }
    }
}
