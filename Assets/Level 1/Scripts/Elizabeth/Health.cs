using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    [SerializeField] private float startingHealth;

    void Start()
    {

        currentHealth = startingHealth;
    }

    private void Update()
    {
        //Change for Enemy hit
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            increaseHealth(1);
        }
    }
    //Damage and health determined later
    public void TakeDamage(float damage)
        
    {
        damage = 1;
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth); //inclusive range 0 and starting

        if (currentHealth > 0)
        {
            Debug.Log("Ouch");
            Debug.Log("Current Health: "+ currentHealth);
           
        }
        else if (currentHealth<= 0)
        {
            Debug.Log("Current Health: " + currentHealth);
            Debug.Log("Dead");

        }
    }
    public void increaseHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth +amount, currentHealth, startingHealth);

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
}
