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

    public GameObject door;
    public bool isDoor = false;
    public bool isDoorDestroyed = false;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>(); //this detects input along the vector and allows movement 
    }

    public void onDoor(InputAction.CallbackContext context)
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
                print("Left faster");
                rb.AddForce(orientation.right * boostForce * Time.deltaTime, ForceMode2D.Impulse);
            }

            if (isRight == false)
            {
                print("faster");
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

  /*  public void DoorOptions()
    {
        if (isDoor == true)
        {
            if (isDoorDestroyed == false)
            {
                
            }
           
        }

    }*/

    public void OpenDoor()
    {
        door.gameObject.SetActive(false);
    }

    public void CloseDoor()
    {
        door.gameObject.SetActive(true);
    }

    public void SetIsDoor(bool state) //this is used to allow me to check for leftwall in a collsion script
    {
        isDoor= state;
    }

}
