using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLvl3 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public float moveInput;
    public Rigidbody2D rb;
    public bool grounded = true;
    bool spacebarPressed = true;
    //Make Animations Smoother Later

    private PlayerAnimationControllerLvl3 playerAnimationController; //Controls animation

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimationController = GetComponent<PlayerAnimationControllerLvl3>(); // Reference the animation script
    }

    private void Update()
    {
        Move();
        Jump();

        float verticalVelocity = rb.velocity.y;

        //Sends speed and grounded state to animation script function
        playerAnimationController.UpdateAnimation(moveInput, grounded, verticalVelocity, spacebarPressed);
    }
    private void Move()
    {
        moveInput = Input.GetAxis("Horizontal");
        // Move the player
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //Flip Sprite 
        playerAnimationController.FlipSprite(moveInput);

    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            grounded = false;
            spacebarPressed = true;
        }
    }
    //Collision checks for grounded (Doesn't use raycast or box)
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            spacebarPressed = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

    public float CalculateSpeed(float distance, float time)
    {
        // another function call
        if (time <= 0) return 0;
        return distance / time;
    }
}
