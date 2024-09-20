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

            if (movement != null)
            {
                movement.SetKitchenFood(true);

                if (movement.hasPicked == true)
                {
                    Destroy(collision.gameObject);
                    movement.hasPicked = false;
                }
            }
        }

        if (collision.gameObject.CompareTag("LivingRoom"))
        {

            if (movement != null)
            {
                movement.SetLivingFood(true);

                if (movement.hasPicked == true)
                {
                    Destroy(collision.gameObject);
                    movement.hasPicked = false;
                }
            }
        }

        if (collision.gameObject.CompareTag("DinningRoom"))
        {

            if (movement != null)
            {
                movement.SetDiningFood(true);

                if (movement.hasPicked == true)
                {
                    Destroy(collision.gameObject);
                    movement.hasPicked = false;
                }
            }
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KitchenRoom"))
        { 

            if (movement != null)
            {
                movement.SetKitchenFood(true);

                if (movement.hasPicked == true)
                {
                    Destroy(collision.gameObject);
                    movement.hasPicked = false;
                }
            }
        }

        if (collision.gameObject.CompareTag("LivingRoom"))
        {

            if (movement != null)
            {
                movement.SetLivingFood(true);

                if (movement.hasPicked == true)
                {
                    Destroy(collision.gameObject);
                    movement.hasPicked = false;
                }
            }
        }

        if (collision.gameObject.CompareTag("DinningRoom"))
        {

            if (movement != null)
            {
                movement.SetDiningFood(true);

                if (movement.hasPicked == true)
                {
                    Destroy(collision.gameObject);
                    movement.hasPicked = false;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KitchenRoom"))
        {

            if (movement != null)
            {
                movement.SetKitchenFood(false);

                if (movement.hasPicked == true)
                {
                    Destroy(collision.gameObject);
                    movement.hasPicked = false;
                }
            }
        }

        if (collision.gameObject.CompareTag("LivingRoom"))
        {
            
            if (movement != null)
            {
                movement.SetLivingFood(false);

                if (movement.hasPicked == true)
                {
                    Destroy(collision.gameObject);
                    movement.hasPicked = false;
                }
            }
        }

        if (collision.gameObject.CompareTag("DinningRoom"))
        {

            if (movement != null)
            {
                movement.SetDiningFood(false);

                if (movement.hasPicked == true)
                {
                    Destroy(collision.gameObject);
                    movement.hasPicked = false;
                }
            }
        }
    }

}
