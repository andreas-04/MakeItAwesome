using UnityEngine;

public class BossJump : MonoBehaviour
{
    public float speed = 3f;        // Movement speed
    public float jumpForce = 10f;  // Force applied for jumping
    public Transform player;       // Reference to the player (assign in Inspector)
    public float jumpCooldown = 2f; // Time between jumps

    private Rigidbody2D rb;
    private float lastJumpTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastJumpTime = Time.time;  // Initialize the jump timer
    }

    private void Update()
    {
        MoveTowardsPlayer();  // Move the boss toward the player

        // Jump on cooldown
        if (Time.time > lastJumpTime + jumpCooldown)
        {
            JumpOnPlayer();
            lastJumpTime = Time.time;
        }
    }

    private void MoveTowardsPlayer()
    {
        // Check if the player exists
        if (player != null)
        {
            // Calculate direction toward the player
            float direction = player.position.x - transform.position.x;

            // Move the boss toward the player (adjust speed)
            rb.velocity = new Vector2(Mathf.Sign(direction) * speed, rb.velocity.y);
        }
    }

    public void JumpOnPlayer()
    {
        // Make the boss jump
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Adjust the Y velocity for jumping
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Optionally, handle logic when the boss collides with the ground or other objects
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Boss landed on the ground!");
        }
    }
}
