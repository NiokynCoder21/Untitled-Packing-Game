using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 move;
    public Rigidbody2D rb;
    public Transform orientation;
    public float moveForce;

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
        if (move.x > 0)
        {
            rb.AddForce(orientation.right * moveForce, ForceMode2D.Force);
        }

        if (move.x < 0)
        {
            rb.AddForce(-orientation.right * moveForce, ForceMode2D.Force);
        }

        if (move.y > 0)
        {
            rb.AddForce(orientation.up * moveForce, ForceMode2D.Force);
        }

        if (move.y < 0)
        {
            rb.AddForce(-orientation.up * moveForce, ForceMode2D.Force);
        }
    }
}
