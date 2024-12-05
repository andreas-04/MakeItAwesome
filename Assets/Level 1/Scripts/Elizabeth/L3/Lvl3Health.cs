using UnityEngine;
using UnityEngine.UI;  // For health UI
using UnityEngine.SceneManagement;
using System.Collections;

public class Lvl3Health : MonoBehaviour
{
    public float maxHealth = 100f;        // Maximum health
    public float currentHealth;          // Current health
    public Image healthUI;               // Reference to the health UI Image
    public GameObject wormObject;        // Reference to the worm GameObject
    public GameObject bossObject;        // Reference to the boss GameObject
    public float survivalTime = 30f;     // Time the player must survive
    private float timer;                 // Tracks elapsed time

    private bool survived = false;       // Track if the player has survived

    private void Start()
    {
        currentHealth = maxHealth;       // Initialize health
        UpdateHealthUI();                // Update UI at the start
        timer = 0f;                      // Start timer at 0
        wormObject.SetActive(false);     // Initially hide the worm
    }

    private void Update()
    {
        // Update the timer if the player is still alive and hasn't survived yet
        if (!survived && currentHealth > 0)
        {
            timer += Time.deltaTime; // Count up the timer

            // Check if the survival time is up
            if (timer >= survivalTime)
            {
                survived = true;  // Mark as survived
                StartCoroutine(WormEatsBoss());  // Start the worm's behavior
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;       // Reduce health by the damage amount
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Clamp health between 0 and maxHealth

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();  // Handle player death
        }
    }

    private void UpdateHealthUI()
    {
        healthUI.fillAmount = currentHealth / maxHealth; // Update UI fill amount
    }

    private void Die()
    {
        Debug.Log("Player is dead!");
        // Implement death logic, like restarting the scene or showing a game over screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the current scene
    }

    private IEnumerator WormEatsBoss()
    {
        Debug.Log("Survived! Worm is eating the boss...");

        wormObject.SetActive(true); // Make the worm appear

        Worm wormBehavior = wormObject.GetComponent<Worm>();
        if (wormBehavior != null)
        {
            wormBehavior.StartMovingTowardsBoss(); // Start worm movement
        }

        // Wait for the worm to finish its "eat" animation
        yield return new WaitForSeconds(3f);

        Destroy(bossObject); // Remove the boss from the scene
        yield return new WaitForSeconds(1f); // Optional delay for dramatic effect

        GoToNextScene(); // Load the next scene
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the boss
        if (collision.gameObject.CompareTag("Boss"))
        {
            ContactPoint2D[] contactPoints = new ContactPoint2D[collision.contactCount];
            collision.GetContacts(contactPoints);

            // Check if the collision happened at the top of the player (head area)
            foreach (ContactPoint2D contact in contactPoints)
            {
                if (contact.point.y > transform.position.y + 0.5f) // Adjust the threshold as needed
                {
                    TakeDamage(20f); // Example damage amount
                    Debug.Log("Player took damage from boss!");
                }
            }
        }
    }

    private void GoToNextScene()
    {
        Debug.Log("Player survived! Loading next scene...");
        // Replace "End" with the actual name of your next scene
        SceneManager.LoadScene("End");
    }
}
