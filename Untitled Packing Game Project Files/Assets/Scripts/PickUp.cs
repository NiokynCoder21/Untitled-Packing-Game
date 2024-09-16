using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour //this is logic for setting isGroceries true
{
    public PlayerMovement movement;

    //we want the player to 1. make the object they collided with disappear 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KitchenRoom"))
        {
            movement.SetKitchenFood(true);
        }

        if (collision.gameObject.CompareTag("LivingRoom"))
        {
            movement.SetLivingFood(true);
        }

        if (collision.gameObject.CompareTag("DinningRoom"))
        {
            movement.SetDiningFood(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("KitchenRoom"))
        {
            movement.SetKitchenFood(true);
        }

        if (other.gameObject.CompareTag("LivingRoom"))
        {
            movement.SetLivingFood(true);
        }

        if (other.gameObject.CompareTag("DinningRoom"))
        {
            movement.SetDiningFood(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KitchenRoom"))
        {
            movement.SetKitchenFood(false);
        }

        if (collision.gameObject.CompareTag("LivingRoom"))
        {
            movement.SetLivingFood(false);
        }

        if (collision.gameObject.CompareTag("DinningRoom"))
        {
            movement.SetDiningFood(false);
        }
    }

}
