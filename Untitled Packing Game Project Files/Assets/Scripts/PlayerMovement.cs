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

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>(); //this detects input along the vector and allows movement 
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
            rb.AddForce(orientation.right * moveForce, ForceMode2D.Force);
            spriteRenderer.flipX = true; //changes the sprites direction to the right
            isRight = true;
            isMoving = true;
        }

        if (normalizedMove.x < 0)
        {
            rb.AddForce(-orientation.right * moveForce, ForceMode2D.Force);
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
}
