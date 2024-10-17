using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using System.Diagnostics;

public class CadenS_EnemyStressTest
{
    private GameObject enemyPrefab;
    private GameObject[] enemies;
    private int numberOfEnemies = 1000; // The number of enemies to spawn
    private float testDuration = 5f; // Time to run the stress test (in seconds)
    private Stopwatch stopwatch;
    

    // Setup method to initialize the test environment
    [SetUp]
    public void Setup()
    {
        // Create an enemy prefab with basic components (Rigidbody and Collider)
        enemyPrefab = new GameObject("EnemyPrefab");
        enemyPrefab.AddComponent<Rigidbody>().useGravity = false;
        enemyPrefab.AddComponent<BoxCollider>();

        // Initialize the array to hold multiple enemy instances
        enemies = new GameObject[numberOfEnemies];

        // Initialize stopwatch for tracking performance
        stopwatch = new Stopwatch();
    }

    // Stress test to spawn 1000 enemies and move them randomly
    [UnityTest]
    public IEnumerator EnemyStressTest_Run()
    {
        stopwatch.Start();

        // Step 1: Spawn all the enemy instances
        for (int i = 0; i < numberOfEnemies; i++)
        {
            enemies[i] = Object.Instantiate(enemyPrefab);
            enemies[i].transform.position = GetRandomPosition();
        }

        // Log that the enemies have been successfully spawned
        UnityEngine.Debug.Log($"{numberOfEnemies} enemies spawned successfully!");

        // Step 2: Randomly move the enemies for a specified test duration
        float startTime = Time.time;
        while (Time.time - startTime < testDuration)
        {
            foreach (GameObject enemy in enemies)
            {
                if (enemy != null)
                {
                    // Move each enemy to a random direction
                    Vector3 randomDirection = GetRandomDirection();
                    enemy.transform.Translate(randomDirection * Time.deltaTime * 10f); // Speed up movement
                }
            }
            yield return null; // Wait for the next frame
        }

        stopwatch.Stop();

        // Step 3: Validate that enemies are still active after the stress test
        int activeEnemies = 0;
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
                activeEnemies++;
        }

        // Assert that the enemies are still active and functional
        Assert.AreEqual(numberOfEnemies, activeEnemies, "Not all enemies survived the stress test");

        // Log the results
        UnityEngine.Debug.Log($"Stress test completed. All {numberOfEnemies} enemies are still active.");
        UnityEngine.Debug.Log($"Test duration: {stopwatch.Elapsed.TotalSeconds} seconds.");
    }

    // Utility method to get a random position within the scene
    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
    }

    // Utility method to get a random direction for movement
    private Vector3 GetRandomDirection()
    {
        return new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }

    // Tear down the test and clean up objects
    [TearDown]
    public void TearDown()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
                Object.DestroyImmediate(enemy);
        }
        Object.DestroyImmediate(enemyPrefab);
    }
}
