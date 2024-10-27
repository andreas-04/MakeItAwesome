using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class ElizabethS_HighSpeedCollisionTest
{
    private bool sceneLoaded;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadScene("Scenes/Level1", LoadSceneMode.Single);
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        sceneLoaded = true;
    }

    [UnityTest]
    public IEnumerator RamIntoEnemyTest()
    {
        yield return new WaitWhile(() => !sceneLoaded);

        // Find the Player and Enemy in the scene
        var player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        var enemy = GameObject.Find("Enemy");

        // Ensure Player and Enemy are found
        Assert.IsNotNull(player, "Player not found!");
        Assert.IsNotNull(enemy, "Enemy not found!");

        // Set the enemy's position to be stationary
        enemy.transform.position = new Vector3(-110, -43, 0); // Adjust this based on your scene setup

        // Initialize player position close to the enemy
        player.transform.position = new Vector3(-116, -43, 0);

        // Start with an initial speed and gradually increase it
        float initialSpeed = 5f; // Starting speed
        float speedIncrement = 2f; // Speed increment
        float waitTime = 0.1f; // Wait time for collision detection
        bool collisionDetected = false; // Track collision state

        while (true) // Loop indefinitely until collision or position condition is met
        {
            // Reset player to the initial position before each new speed test
            player.transform.position = new Vector3(-116, -43, 0);
            collisionDetected = false; // Reset the collision flag

            // Apply velocity to the player to move right into the enemy
            for (int frame = 0; frame < 500; frame++) // Simulate movement for 500 frames
            {
                player.transform.position += Vector3.right * initialSpeed * Time.deltaTime;
                yield return new WaitForSeconds(waitTime); // Wait for a specified time to allow for collision

                // Check for collision
                if (Physics2D.IsTouching(player.GetComponent<Collider2D>(), enemy.GetComponent<Collider2D>()))
                {
                    Debug.Log($"Collision detected at speed: {initialSpeed}");
                    collisionDetected = true; // Collision occurred
                    break; // Exit the loop if a collision is detected
                }

                // Check if player has moved past -108 on the x-axis
                if (player.transform.position.x > -108)
                {
                    Assert.Fail("Player moved past -108, breaking collision");
                    yield break; // Exit the test if the player moves past -108
                }
            }

            // If a collision was detected, increase the speed for the next attempt
            if (collisionDetected)
            {
                initialSpeed += speedIncrement; // Increase speed for next iteration
            }
            else
            {
                Debug.Log($"No collision detected at speed: {initialSpeed}");
                break; 
            }
        }

        // If collision was never detected, the test fails. Collider is broken
        Assert.IsFalse(collisionDetected, $"Collision was detected at speed: {initialSpeed}. Collider Broken.");
        yield return null; // Ensure the test completes
    }
}
