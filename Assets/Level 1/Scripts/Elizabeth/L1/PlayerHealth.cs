using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Subject
{
    public float currentHealth;
    [SerializeField] private float startingHealth = 100f;

    void Start()
    {
        currentHealth = startingHealth;
    }

    private void Update()
    {
        // Simulate taking damage and healing with key presses
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(10);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseHealth(10);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name); // Check which object was hit

        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
            Debug.Log("Player hit by enemy, taking damage");
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);  // Keep health between 0 and starting health
        NotifyObserver(PlayerActions.damaged, currentHealth);  // Notify observers with the current health

        if (currentHealth <= 0)
        {
            Debug.Log("Dead");
            Debug.Log("Current Health: " + currentHealth);
            GetComponent<PlayerAnimationController>().PlayDeadAnimation();

        }
    }

    public void IncreaseHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, startingHealth);  // Keep health between 0 and starting health
        NotifyObserver(PlayerActions.healed, currentHealth);  // Notify observers with the current health

        if (currentHealth == startingHealth)
        {
            Debug.Log("Current Health: " + currentHealth);
            Debug.Log("Full Health");
        }
    }


}