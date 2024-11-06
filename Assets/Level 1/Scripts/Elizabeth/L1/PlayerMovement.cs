using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public float moveInput;
    public Rigidbody2D rb;

    bool spacebarPressed = true;
    //Make Animations Smoother Later

    //For Grounded Check
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    public bool grounded = true;
    private PlayerAnimationController playerAnimationController; //Controls animation

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimationController = GetComponent<PlayerAnimationController>(); // Reference the animation script
    }

    private void Update()
    {
        Move();
        Jump();

        float verticalVelocity = rb.velocity.y;
        grounded = isGrounded();

        if (grounded)
        {
            // TODO: Play sound affect here
        }

        //Sends speed and grounded state to animation script function
        playerAnimationController.UpdateAnimation(moveInput, grounded, verticalVelocity, spacebarPressed);
    }
    public void Move()
    {
        moveInput = Input.GetAxis("Horizontal");
        // Move the player
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //Flip Sprite 
        playerAnimationController.FlipSprite(moveInput);

    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            spacebarPressed = true;
        }
    }

    //Up and Down hills smoother
    public bool isGrounded()
    {
        // Cast two rays from the left and right edges of the player to check for ground
        float offset = 0.5f; // Distance from the center to the edges
        Vector2 leftRayOrigin = new Vector2(transform.position.x - offset, transform.position.y);
        Vector2 rightRayOrigin = new Vector2(transform.position.x + offset, transform.position.y);

        // Cast rays downwards
        RaycastHit2D leftRayHit = Physics2D.Raycast(leftRayOrigin, Vector2.down, castDistance, groundLayer);
        RaycastHit2D rightRayHit = Physics2D.Raycast(rightRayOrigin, Vector2.down, castDistance, groundLayer);

        // Return true if either ray hits the ground
        if (leftRayHit.collider != null || rightRayHit.collider != null)
        {
            return true;
        }

        return false;
    }


    private void OnDrawGizmos()
    {
        // Visualize the BoxCast in the Editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }

    public float CalculateSpeed(float distance, float time)
    {
        // another function call
        if (time <= 0) return 0;
        return distance / time;
    }
}
