using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public Rigidbody2D rb;

    public bool grounded = true;
    private bool isJumping = false;  // Track whether the player is jumping
    private PlayerAnimationController playerAnimationController; // Controls animation

    // For Grounded Check
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    // Joystick reference for mobile controls (assign in the Inspector if needed)
    public Joystick joystick;
    public Button attackButton;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimationController = GetComponent<PlayerAnimationController>(); // Reference the animation script

        if (attackButton != null)
        {
            attackButton.onClick.AddListener(PerformAttack);  // Trigger attack when button is pressed
        }
    }

    private void Update()
    {
        Move();

        float verticalVelocity = rb.velocity.y;
        grounded = isGrounded();

        // Update the animation state (grounded, jumping, etc.)
        playerAnimationController.UpdateAnimation(GetMoveInput(), grounded, verticalVelocity, isJumping);

        // Handle jump input for both desktop and mobile
        if (grounded && (Input.GetKeyDown(KeyCode.Space) || joystick.Vertical > 0.5f))
        {
            Jump();
        }

        // Handle attack input (for fist attack)
        if (Input.GetKeyDown(KeyCode.X) || Input.GetMouseButtonDown(0)) // Example key for attack (X)
        {
            PerformAttack();
            
        }
    }

    private void Move()
    {
        // AudioManager.Instance.PlaySFX(1);
        float moveInput = GetMoveInput();

        // Move the player horizontally
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Flip Sprite based on movement direction
        playerAnimationController.FlipSprite(moveInput);
    }

    private void Jump()
    {
        AudioManager.Instance.PlaySFX(3);
        // Set the player as jumping
        isJumping = true;

        // Apply upward force to make the player jump
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private float GetMoveInput()
    {
#if UNITY_IOS || UNITY_ANDROID
        return joystick.Horizontal;  // Mobile joystick input
#else
        return Input.GetAxis("Horizontal");  // Desktop keyboard input
#endif
    }

    public bool isGrounded()
    {
        float offset = 0.5f;
        Vector2 leftRayOrigin = new Vector2(transform.position.x - offset, transform.position.y);
        Vector2 rightRayOrigin = new Vector2(transform.position.x + offset, transform.position.y);

        RaycastHit2D leftRayHit = Physics2D.Raycast(leftRayOrigin, Vector2.down, castDistance, groundLayer);
        RaycastHit2D rightRayHit = Physics2D.Raycast(rightRayOrigin, Vector2.down, castDistance, groundLayer);

        return leftRayHit.collider != null || rightRayHit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }

    private void PerformAttack()
    {
        AudioManager.Instance.PlaySFX(2);
        // Notify the animation controller to play the fist attack animation
        playerAnimationController.PlayFistAttack();
    }
    public float CalculateSpeed(float distance, float time)
    {
        // another function call
        if (time <= 0) return 0;
        return distance / time;
    }
}
