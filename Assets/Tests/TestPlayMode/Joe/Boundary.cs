using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class Boundary
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
    public IEnumerator boundarySuccessTest()
    {
        yield return new WaitWhile(() => sceneLoaded == false);

        // Find the Player and Wall in the scene
        var Player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        var leftWall = GameObject.Find("WallLeft").GetComponent<BoxCollider2D>();

        float initialPlayerPosition = Player.transform.position.x;
        float wallPositionX = leftWall.transform.position.x;

        Debug.Log("Initial Player Position: " + initialPlayerPosition);
        Debug.Log("Wall Position: " + wallPositionX);

        // Simulate stress test of pushing player left (against the wall) for 750 frames
        float speed = -10f;  // Moving left
        for (int i = 0; i < 750; i++)
        {
            Player.rb.velocity = new Vector2(speed, 0);  // Move player to the left
            yield return null;  // Wait for the next frame
        }

        // Check that player has not passed through the wall
        float finalPlayerPosition = Player.transform.position.x;

        Debug.Log("Final Player Position: " + finalPlayerPosition);

        // Assert that the player's final position is not less than the wall's position (can't pass through wall)
        Assert.GreaterOrEqual(finalPlayerPosition, wallPositionX, 
            "Player should not have passed through the wall on the left.");
    }

    [UnityTest]
    public IEnumerator attemptMovePastWall()
    {
        yield return new WaitWhile(() => sceneLoaded == false);

        // Find the Player and Wall in the scene
        var Player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        var leftWall = GameObject.Find("WallLeft").GetComponent<BoxCollider2D>();

        float wallPositionX = leftWall.transform.position.x;

        // Set player's initial position near the wall (just 1 unit to the right of the wall)
        Player.transform.position = new Vector3(wallPositionX + 1f, Player.transform.position.y, Player.transform.position.z);

        Debug.Log("Player initial position: " + Player.transform.position.x);
        Debug.Log("Wall position: " + wallPositionX);

        yield return new WaitForSeconds(1);

        // Apply velocity to the player to move left
        for (int i = 0; i < 100; i++)  // Simulate movement for 100 frames per speed increment
        {
            // Apply a small velocity to the left, attempting to move past the wall
            Player.rb.velocity = new Vector2(-10f, 0);
            yield return null;
        }

        // Apply a small velocity to the left, attempting to move past the wall

        // Wait for 1 second (simulate time for movement)
        yield return new WaitForSeconds(1);

        // Check if the player has passed the wall's X position
        float finalPlayerPositionX = Player.transform.position.x;

        Debug.Log("Player final position: " + finalPlayerPositionX);

        // Assert that the player has not passed the wall (cannot go past the wall)
        Assert.GreaterOrEqual(finalPlayerPositionX, wallPositionX, 
            "Player should not be able to move past the wall.");
    }

}
