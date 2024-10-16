using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Required to access the UI components

public class Health : MonoBehaviour
{
    public float currentHealth;
    [SerializeField] private float startingHealth;
    public Image HealthUI;  // Reference to the UI Image

    void Start()
    {
        currentHealth = startingHealth;
        UpdateHealthUI();
    }

    private void Update()
    {
        // Simulate taking damage and healing with key presses
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseHealth(1);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth); // Keep health between 0 and starting health
        UpdateHealthUI();

        if (currentHealth > 0)
        {
            Debug.Log("Ouch");
            Debug.Log("Current Health: " + currentHealth);
        }
        else if (currentHealth <= 0)
        {
            Debug.Log("Current Health: " + currentHealth);
            Debug.Log("Dead");
        }
    }

    public void IncreaseHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, startingHealth);  // Keep health between 0 and starting health
        UpdateHealthUI();

        if (currentHealth == startingHealth)
        {
            Debug.Log("Current Health: " + currentHealth);
            Debug.Log("Full Health");
        }
        else if (currentHealth < startingHealth)
        {
            Debug.Log("Health Increased");
            Debug.Log("Current Health: " + currentHealth);
        }
    }

    private void UpdateHealthUI()
    {
        // Set the fill amount of the HealthUI Image
        HealthUI.fillAmount = currentHealth / startingHealth;  // Normalize current health to a value between 0 and 1
    }
}
