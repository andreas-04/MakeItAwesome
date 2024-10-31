using System.Collections;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class ElizabethS_PlayerJumpSpamTest
{
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
    public IEnumerator SpamJumpTest()
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
        playerMovement.grounded = true; // Set grounded state to true

        float initialY = playerObject.transform.position.y; // Track the player's initial Y position for check

        int jumpCount = 0; // counts number of actual jumps

        // Start spamming jumps for 500 frames
        for (int i = 0; i < 500; i++)
        {
            // Check if the player is grounded before jumping
            if (playerMovement.grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, playerMovement.jumpForce);
                jumpCount++; // Increment the jump count only when grounded
                playerMovement.grounded = false; 
            }

            // Update the frame
            yield return new WaitForFixedUpdate();

            // Debug log for monitoring jump count and player position
            Debug.Log($"Jump Count: {jumpCount}");
            Debug.Log($"Player Y Position: {playerObject.transform.position.y}");
            
        }

        // Wait for the player to land after the test
        float maxWaitTime = 3f; // Max time to wait for the player to land --> Makes sure it does not end before the player has fallen
        float elapsedWaitTime = 0f;
        while (!playerMovement.grounded && elapsedWaitTime < maxWaitTime)
        {
            yield return new WaitForFixedUpdate();
            elapsedWaitTime += Time.fixedDeltaTime;

            // Check if the player has stopped falling (vertical velocity close to zero)
            if (Mathf.Abs(rb.velocity.y) < 0.01f)
            {
                playerMovement.grounded = true; // Manually set grounded if velocity is nearly zero
            }
        }

        // Ensure the player has landed
        Assert.IsTrue(playerMovement.grounded, "Player did not land after jumps.");

        // Assert that the player has jumped at least once
        Assert.IsTrue(jumpCount > 0, "Player should have jumped at least once during the test.");
        Debug.Log($"Total Jumps: {jumpCount}");
       
        // Check that the player returned to their initial Y position (or close enough within a small margin)
        float finalY = playerObject.transform.position.y;
        int roundedInitialY = Mathf.RoundToInt(initialY);
        int roundedFinalY = Mathf.RoundToInt(finalY);
        Assert.AreEqual(roundedInitialY, roundedFinalY, $"Player's final Y position ({roundedFinalY}) does not match initial Y position ({roundedInitialY}).");
        Debug.Log("Test passed: Player returned to initial Y position.");
    }
}
