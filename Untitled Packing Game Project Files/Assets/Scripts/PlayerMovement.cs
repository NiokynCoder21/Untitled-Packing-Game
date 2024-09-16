using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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
    public int scoreKitchen;
    public int scoreLiving;
    public int scoreDining;
    public bool isGrocery = false;
    public bool kitchenFood = false; //this is to check whether the player is touching kitchen groceries or not
    public bool diningFood = false; // this is to check whether the player is touching dining groceries or not
    public bool livingFood = false; //this is to check whether the player is touching living groceries or not

    public Image pinkGroceryUI;
    public Image blueGroceryUI;
    public Image purpleGroceryUI;

    public int loseKitchen;
    public int loseLiving;
    public int loseDining;

    public bool selectedKitchen = false;
    public bool selectedDining = false;
    public bool selectedLiving = false;

    public bool hasPicked = false; //this is to track whether the player has picked up a something or not

    public enum GroceryType
    {
        KitchenStuff,
        LivingRoomStuff,
        DiningRoomStuff,
    }

    public GroceryType selectedGrocery = GroceryType.KitchenStuff;

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

            if (kitchenFood == true)
            {
                PickUp();
                hasPicked = true;
            }

            if (livingFood == true)
            {
                PickUp();
                hasPicked = true;
            }

            if (diningFood == true)
            {
                PickUp();
                hasPicked = true;
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

    public void onLeftSelection(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SwitchSelection(-1);
        }
    }

    public void onRightSelect(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SwitchSelection(1);
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
                switch (selectedGrocery)
                {
                    case GroceryType.KitchenStuff:
                        selectedKitchen = true;
                        selectedLiving = false;
                        selectedDining = false;

                        if (selectedKitchen == true)
                        {
                          scoreManager.AwardKitchenPoints(scoreKitchen);
                          itemManager.LossKitchenStuff(addItems, loseKitchen);
                        }

                        break;

                    case GroceryType.DiningRoomStuff:
                       
                        selectedKitchen = false;
                        selectedLiving = false;
                        selectedDining = true;

                        if (selectedDining == true)
                        {
                          scoreManager.AwardDiningPoints(scoreDining);
                          itemManager.LossDiningStuff(addItems, loseDining);
                        }

                    break;

                    case GroceryType.LivingRoomStuff:
                        
                        selectedKitchen = false;
                        selectedLiving = true;
                        selectedDining = false;

                        if (selectedLiving == true)
                        {
                          scoreManager.AwardLivingPoints(scoreLiving);
                          itemManager.LossLivingStuff(addItems, loseLiving);
                        }

                    break;
                }
            
        }

    }

    public void SwitchSelection(int direction)
    {
        int newSelection = ((int)selectedGrocery + direction) % 3;
        if (newSelection < 0) newSelection += 3;
        selectedGrocery = (GroceryType)newSelection;

        UpdateUI();
    }

    public void UpdateUI()
    {
        pinkGroceryUI.GetComponent< Image>().color = Color.black; // Default color for kitchen
        purpleGroceryUI.GetComponent<Image>().color = Color.black; // Default color for living room
        blueGroceryUI.GetComponent<Image>().color = Color.black; // Default color for dining room

        // Highlight the selected grocery
        switch (selectedGrocery)
        {
            case GroceryType.KitchenStuff:
                pinkGroceryUI.GetComponent<Image>().color = Color.red; // Highlight kitchen
                break;
            case GroceryType.LivingRoomStuff:
                purpleGroceryUI.GetComponent<Image>().color = Color.red; // Highlight living room
                break;
            case GroceryType.DiningRoomStuff:
                blueGroceryUI.GetComponent<Image>().color = Color.red; // Highlight dining room
                break;
        }
    }

    public void SetIsDoor(bool state) //this is used to allow me to check for leftwall in a collsion script
    {
        isDoor = state;
    }

  
    public void SetKitchenFood(bool state)
    {
        kitchenFood = state;
    }

    public void SetDiningFood(bool state)
    {
        diningFood = state;
    }

    public void SetLivingFood(bool state)
    {
        livingFood = state;
    }

}
