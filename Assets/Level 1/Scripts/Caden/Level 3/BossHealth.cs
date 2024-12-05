using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health = 500;
    public GameObject deathEffect;
    public bool isInvulnerable = false;
    public BossHealthScript healthbar;  // Reference to the health bar script

    void Start()
    {
        healthbar.SetMaxHealth(health);  // Initialize health bar with max health
    }

    // Function to apply damage to the boss
    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        health -= damage;  // Reduce health by the damage value
        healthbar.SetHealth(health);  // Update the health bar

        if (health <= 200)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);  // Trigger boss enraged state when health is low
        }

        if (health <= 0)
        {
            Die();  // Trigger death when health reaches 0
        }
    }

    // Handle the boss's death
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);  // Show death effect
        Destroy(gameObject);  // Destroy the boss
    }
}
