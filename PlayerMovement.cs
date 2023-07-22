using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    //Awake is called after all objects are initiallized. Call in a random order.
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Will look for a component of this Gameobject (what the script is attached to) of type Rigidbody2D.
    }

    // Update is called once per frame
    void Update()
    {
        // Get inputs
        moveDirection = Input.GetAxis("Horizontal"); // scale of -1 -> 1

        // Animate
        if (moveDirection >  0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection > 0 && facingRight)
        {
            FlipCharacter();
        }


       // Move
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

}
