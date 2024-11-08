using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControllerLvl3 : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
    }

    // Called by PlayerMovement to handle animations
    public void UpdateAnimation(float speed, bool isGrounded, float verticalVelocity, bool spacebarPressed)
    {
        // Update Animator parameters based on the player's speed and grounded state
        animator.SetFloat("Speed", Mathf.Abs(speed));
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("VerticalVelocity", verticalVelocity); // For Falling
        animator.SetBool("spacePressed", spacebarPressed);


    }

    // This function handles flipping the sprite direction based on movement direction
    public void FlipSprite(float moveInput)
    {
        if (moveInput > 0)
        {
            spriteRenderer.flipX = true; // Face right
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = false; // Face left
        }
    }

    // Method to trigger the death animation
    public void PlayDeadAnimation()
    {
        animator.SetTrigger("DeadTrigger"); // Using a trigger parameter for death
    }

    public void PlayAttackAnimation(string triggerName)
    {
        animator.SetTrigger(triggerName); // Set the trigger based on equipped weapon 
    }
}
