using System.Collections;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class ElizabethS_PlayerJumpForceTest
{
    private bool sceneLoaded;

    // Load Scene
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

        var enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy != null)
        {
            enemy.SetActive(false);
        }

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

        float initialJumpForce = playerMovement.jumpForce; // Track initial jump force
        float jumpForce = initialJumpForce; // Initialize jump force variable

        // Start spamming jumps until going out of bounds
        while (true)
        {
            // Check if the player is grounded before jumping
            if (playerMovement.grounded)
            {
                Debug.Log($"Jump Foce: {jumpForce}");
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                playerMovement.grounded = false;
                jumpForce += 5; // Increase jump force
            }

            // Update the frame
            yield return new WaitForFixedUpdate();

            // Check if the player has gone out of bounds
            if (playerObject.transform.position.y > -33)
            {
                break; // Exit the loop if the player has gone out of bounds
            }
        }

        // Assert that the player went out of bounds
        Assert.IsFalse(playerObject.transform.position.y > -33, "Player went out of bounds.");
    }
}
