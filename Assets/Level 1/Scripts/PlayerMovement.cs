using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;

    public Rigidbody2D rb;
    bool grounded = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
    }
    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        // Move the player
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    //Collision checks for grounded
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
