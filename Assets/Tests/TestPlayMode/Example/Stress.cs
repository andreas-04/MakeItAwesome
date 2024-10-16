using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class ExampleStress
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
    public IEnumerator moveLeftBoarderStress()
    {
        yield return new WaitWhile(() => sceneLoaded == false);

        // Find the Player and Wall in the scene
        var Player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        var leftWall = GameObject.Find("WallLeft").GetComponent<BoxCollider2D>();

        float initialPlayerPositionX = Player.transform.position.x;  // Store initial X position
        Vector3 initialPlayerPosition = Player.transform.position;  // Store full initial position
        float wallPositionX = leftWall.transform.position.x;

        Debug.Log("Initial Player Position: " + initialPlayerPositionX);
        Debug.Log("Wall Position: " + wallPositionX);

        // Start with an initial speed and gradually increase it
        float speed = -20f;  // Start with a slow speed to the left
        float speedIncrement = -10f;  // Gradually increase speed
        bool playerPassedThroughWall = false;

        while (!playerPassedThroughWall)
        {
            // Reset player to initial position before each new speed test
            Player.transform.position = initialPlayerPosition;

            // Apply velocity to the player to move left
            for (int i = 0; i < 700; i++)  // Simulate movement for 100 frames per speed increment
            {
                Player.rb.velocity = new Vector2(speed, 0);
                yield return null;


                // Check if player passed through the wall
                if (Player.transform.position.x < wallPositionX)
                {
                    Debug.Log("Player passed through the wall at speed: " + Mathf.Abs(speed));
                    playerPassedThroughWall = true;
                    break;  // Exit the loop if the player passes through the wall
                }
            }

            yield return new WaitForSeconds(1); 

            if (!playerPassedThroughWall)
            {
                // If the player hasn't passed through the wall, increase the speed and reset
                speed += speedIncrement;
            }
            Debug.Log("Current Player speed: " + Mathf.Abs(speed));
            yield return new WaitForSeconds(1); 
        }

        // If the player passes through the wall, fail the test and log the speed
        Assert.Pass("Player passed through the wall at speed: " + Mathf.Abs(speed));
        yield return new WaitForSeconds(1); 
    }

}
