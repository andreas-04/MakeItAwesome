using System.Collections;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class ElizabethS_BoundaryRightWall
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
    public IEnumerator MovePastRightWallAttempt()
    {
        yield return new WaitWhile(() => !sceneLoaded);

        // Find the Player and Wall in the scene
        var player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        var rightWall = GameObject.Find("WallRight").GetComponent<BoxCollider2D>();

        float wallPositionX = rightWall.transform.position.x;

        // Set player's initial position near the wall (just 1 unit to the right of the wall)
        player.transform.position = new Vector3(wallPositionX + 1f, player.transform.position.y, player.transform.position.z);

        Debug.Log("Player initial position: " + player.transform.position.x);
        Debug.Log("Wall position: " + wallPositionX);

        yield return new WaitForSeconds(1);

        // Attempt to move past the wall 5 times
        for (int attempt = 0; attempt < 5; attempt++)
        {
            // Apply velocity to the player to move Right
            player.rb.velocity = new Vector2(10f, 0);

            // Wait for a moment to simulate movement
            yield return new WaitForSeconds(1);

            // Check if the player has passed the wall's X position
            float finalPlayerPositionX = player.transform.position.x;
            Debug.Log($"Attempt {attempt + 1}: Player final position: {finalPlayerPositionX}");

            // Assert that the player has not passed the wall (cannot go past the wall)
            Assert.GreaterOrEqual(finalPlayerPositionX, wallPositionX,
                $"Player should not be able to move past the wall on attempt {attempt + 1}.");

            // Reset the player's position for the next attempt
            player.transform.position = new Vector3(wallPositionX + 1f, player.transform.position.y, player.transform.position.z);
        }

        yield return null; // Ensure the test completes
    }
}


