using UnityEngine;
using System.Collections;

public class Worm : MonoBehaviour
{
    public float moveSpeed = 2f;  // Worm speed (adjustable)
    private GameObject boss;      // Reference to the boss object
    private bool isMovingTowardsBoss = false; // Flag to track worm movement
    private bool isEatingBoss = false;  // Flag to track if worm is eating boss

    public float damagePerSecond = 5f; // Amount of damage per second while the worm eats the boss
    public float eatingDuration = 5f;  // Duration for which the worm eats the boss

    private void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");  // Find the boss in the scene by its tag
        if (boss == null)
        {
            Debug.LogError("Boss not found! Make sure the boss has the tag 'Boss'.");
        }
    }

    void Update()
    {
        if (isMovingTowardsBoss && !isEatingBoss)
        {
            MoveTowardsBoss();  // Move the worm towards the boss when it's activated
        }
    }

    // Method to start the worm moving towards the boss
    public void StartMovingTowardsBoss()
    {
        if (boss != null)
        {
            isMovingTowardsBoss = true;  // Start moving
            Debug.Log("Worm started moving towards the boss.");
        }
    }

    // Moves the worm towards the boss
    private void MoveTowardsBoss()
    {
        if (boss != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, boss.transform.position, moveSpeed * Time.deltaTime);  // Move worm towards boss

            // If the worm reaches the boss, start the eating process
            if (transform.position == boss.transform.position && !isEatingBoss)
            {
                StartWormEating();  // Trigger the worm eating the boss
            }
        }
    }

    // Starts the process of the worm eating the boss
    private void StartWormEating()
    {
        isEatingBoss = true;  // Flag to indicate the worm is eating the boss
        Debug.Log("Worm is eating the boss.");

        // Start damage over time while the worm eats the boss
        StartCoroutine(EatBossAndDamageHealth());
    }

    // Coroutine to handle damage to the boss over time while worm eats it
    private IEnumerator EatBossAndDamageHealth()
    {
        float elapsedTime = 0f;

        // While the worm is eating, continue to damage the boss
        while (elapsedTime < eatingDuration)
        {
            // Call the TakeDamage function of the BossHealth script
            BossHealth bossHealth = boss.GetComponent<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.TakeDamage((int)damagePerSecond); // Apply damage to the boss
            }

            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Once the worm is done eating, finish the process
        Debug.Log("Worm finished eating the boss.");

        // Optionally, you could destroy the worm or disable it at this point
        Destroy(gameObject);  // Or disable worm if needed
    }
}
