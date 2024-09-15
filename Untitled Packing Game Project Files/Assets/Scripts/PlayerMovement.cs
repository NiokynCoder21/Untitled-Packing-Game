using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 move;
    public Rigidbody2D rb;
    public Transform orientation;
    public float moveForce;
    public SpriteRenderer spriteRenderer;
    public bool isRight = false;
    public bool isMoving = false;
    public float boostForce;

    public int addItems;
    public int addKitchen;
    public int addLiving;
    public int addDining;

    public GameObject door;
    public bool isDoor = false;
    public bool isDoorDestroyed = false;
    public bool isCar;

    public ItemManager itemManager;
    public ScoreManager scoreManager;
    public int scoreAmount;
    public int moreScoreAmount;
    public int lesserScoreAmount;
    public bool isGrocery = false;
    public bool kitchenFood = false; //this is to check whether the player is touching kitchen groceries or not
    public bool diningFood = false; // this is to check whether the player is touching dining groceries or not
    public bool livingFood = false; 

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>(); //this detects input along the vector and allows movement 
    }

    public void onDoor(InputAction.CallbackContext context)
    {
        if(isDoor == true)
        {
            if (context.performed)
            {
                if (isDoorDestroyed == false)
                {
                    OpenDoor();
                    isDoorDestroyed = true;
                }

                else
                {
                    CloseDoor();
                    isDoorDestroyed = false;
                }
            }
        }
        
    }

    public void onCar(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
           /* if (scoreManager != null)
            {
                if (scoreManager.isKitchen == true || scoreManager.isLivingRoom == true || scoreManager.isDiningRoom == true) //if the player is on this area
                {
                    DropItem();
                }
            }*/

            if (isGrocery == true) //if the player is touching groceries 
            {
                PickUp();
            }

        }

    }

    public void onDrop(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DropItem();
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        Vector2 normalizedMove = move.magnitude > 1 ? move.normalized : move;

        if (normalizedMove.x > 0)
        {
            rb.AddForce(orientation.right * moveForce * Time.deltaTime, ForceMode2D.Force);
            spriteRenderer.flipX = true; //changes the sprites direction to the right
            isRight = true;
            isMoving = true;
        }

        if (normalizedMove.x < 0)
        {
            rb.AddForce(-orientation.right * moveForce * Time.deltaTime, ForceMode2D.Force);
            spriteRenderer.flipX = false; //changes the sprites direction to the left
            isRight = false;
            isMoving = true;
        }

        if (isMoving)
        {
            if (isRight == true)
            {
                rb.AddForce(orientation.right * boostForce * Time.deltaTime, ForceMode2D.Impulse);
            }

            if (isRight == false)
            {
                rb.AddForce(-orientation.right * boostForce * Time.deltaTime, ForceMode2D.Impulse);
            }
        }

        if (normalizedMove.y > 0)
        {
            rb.AddForce(orientation.up * moveForce, ForceMode2D.Force);
        }

        if (normalizedMove.y < 0)
        {
            rb.AddForce(-orientation.up * moveForce, ForceMode2D.Force);
        }

        if (move == Vector2.zero)
        {
            rb.velocity *= 0.1f; // Reduces the velocity gradually
            isMoving = false;
        }
    }

    public void OpenDoor()
    {
        door.gameObject.SetActive(false);
    }

    public void CloseDoor()
    {
        door.gameObject.SetActive(true);
    }

    public void PickUp()
    {
        if (itemManager != null)
        {
            if (itemManager.currentItems < 5)
            {
                itemManager.AwardItems(addItems, addKitchen, addLiving, addDining);
            }

           
        }
    }

    public void DropItem()
    {
        if (itemManager != null && scoreManager != null)
        {
            if (itemManager.currentItems > 0)
            {
                itemManager.LossItems(addItems, addKitchen, addLiving, addDining);
                scoreManager.AwardItems(scoreAmount, moreScoreAmount, lesserScoreAmount);

            }
        }
    }

    public void SetIsDoor(bool state) //this is used to allow me to check for leftwall in a collsion script
    {
        isDoor = state;
    }

    public void SetIsCar(bool state)
    {
        isCar = state;
    }

    public void SetIsGrocery(bool state)
    {
        isGrocery = state;
    }

    public void SetKitchenFood(bool state)
    {

    }

}
