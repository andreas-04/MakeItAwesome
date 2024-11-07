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

    private PlayerAnimationControllerLvl3 playerAnimationController; // Controls animation

    // Joystick reference for mobile controls (assign in the Inspector if needed)
    public Joystick joystick; // Ensure you have a joystick component set up for mobile controls

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimationController = GetComponent<PlayerAnimationControllerLvl3>(); // Reference the animation script
    }

    private void Update()
    {
        // Move and jump using the appropriate input source (keyboard or joystick)
        Move();
        Jump();

        float verticalVelocity = rb.velocity.y;

        // Sends speed and grounded state to animation script function
        playerAnimationController.UpdateAnimation(moveInput, grounded, verticalVelocity, spacebarPressed);
    }

    private void Move()
    {
        // Check if mobile joystick is being used, otherwise default to keyboard input
#if UNITY_IOS || UNITY_ANDROID
        moveInput = joystick.Horizontal;  // Use joystick for horizontal movement on mobile
#else
        moveInput = Input.GetAxis("Horizontal");  // Use keyboard for horizontal movement on desktop
#endif

        // Move the player
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Flip Sprite based on movement direction
        playerAnimationController.FlipSprite(moveInput);
    }

    private void Jump()
    {
        // Check if jump is pressed (space for keyboard, joystick for mobile)
#if UNITY_IOS || UNITY_ANDROID
        if (joystick.Vertical > 0.5f && grounded)  // Adjust the threshold as needed
#else
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
#endif
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            grounded = false;
            spacebarPressed = true;
        }
    }

    // Collision checks for grounded (Doesn't use raycast or box)
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
        // Another function call
        if (time <= 0) return 0;
        return distance / time;
    }
}
