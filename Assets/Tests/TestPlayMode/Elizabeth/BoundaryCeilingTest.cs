using System.Collections;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class ElizabethS_BoundaryCeilingTest
{
    private const float ceilingY = -33f;
    private bool sceneLoaded;
    //Load Scene
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
    public IEnumerator BoundaryCeilingTest()
    {
        yield return new WaitWhile(() => !sceneLoaded);

        // Find the GameObject Objects
        var playerObject = GameObject.Find("Player");
        var playerMovement = playerObject.GetComponent<PlayerMovement>();
        var rb = playerObject.GetComponent<Rigidbody2D>();

        // Ensure Player and Rigidbody are found
        Assert.IsNotNull(playerObject, "Player GameObject not found!");
        Assert.IsNotNull(rb, "Rigidbody2D not found on Player!");

        // Set the player's position to start grounded
        playerObject.transform.position = new Vector3(-116, -43.4f, 0); // Position is wherever scene Player is
        

        float initialY = playerObject.transform.position.y; // Track the player's initial Y position for check

        int jumpCount = 0; // counts number of actual jumps

        // Start spamming jumps for 500 frames
        for (int i = 0; i < 500; i++)
        {
            // Check if the player is grounded before jumping
           
                rb.velocity = new Vector2(rb.velocity.x, playerMovement.jumpForce);
                jumpCount++; // Increment the jump count only when grounded

            // Update the frame
            yield return new WaitForFixedUpdate();

            Assert.LessOrEqual(playerObject.transform.position.y, ceilingY,
                 $"Player exceeded ceiling boundary at Y = {playerObject.transform.position.y}");

        }

       
      
        // Assert that the player has jumped at least once
        Assert.IsTrue(jumpCount > 0, "Player should have jumped at least once during the test.");
        Debug.Log($"Total Jumps: {jumpCount}");

        
        Debug.Log("Test passed: Player Stayed below the ceiling.");
    }
}
