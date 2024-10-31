using System.Collections;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class ElizabethS_FistAttackSpamTest
{
    private bool sceneLoaded;

    // Load Scene
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadScene("Scenes/Level3", LoadSceneMode.Single); // Load the correct scene for your test
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        sceneLoaded = true;
    }

    [UnityTest]
    public IEnumerator SpamStickAttackTest()
    {
        yield return new WaitWhile(() => !sceneLoaded);

        // Find the Player and PlayerAttack components
        var playerObject = GameObject.Find("Player");
        var playerAttack = playerObject.GetComponent<PlayerAttack>();
        var animator = playerObject.GetComponent<Animator>();
        var playerAnimationController = playerObject.GetComponent<PlayerAnimationControllerLvl3>(); // Get the PlayerAnimationController

        Assert.IsNotNull(playerAttack, "PlayerAttack component not found!");
        Assert.IsNotNull(animator, "Animator component not found!");
        Assert.IsNotNull(playerAnimationController, "PlayerAnimationController component not found!"); // Check for the controller

        // Set the player's position to start grounded
        playerObject.transform.position = new Vector3(-6, -4f, 0);

        // Change weapon to FistAttack before spamming
        playerAttack.ChangeWeapon(new Attack());

        int attackCount = 0; // Track how many times we have attacked

        // Spam attack for 500 frames
        for (int i = 0; i < 500; i++)
        {
            // Directly call the current attack's ExecuteAttack method
            playerAttack.currentAttack.ExecuteAttack(playerObject.transform); // Perform the attack

            // Trigger the attack animation using the current weapon's animation trigger
            playerAnimationController.PlayAttackAnimation(playerAttack.currentAttack.AnimationTrigger); // Ensure the correct animation is played
            attackCount++; // Count the attack
            yield return new WaitForFixedUpdate(); // Wait for the next physics frame
        }

        // Wait until the animation state updates to Fist Attack (or timeout after a maximum period)
        bool isAnimationPlaying = false;
        float timer = 0f;
        while (timer < 1f && !isAnimationPlaying) // Adjust timeout as needed
        {
            var currentAnimatorState = animator.GetCurrentAnimatorStateInfo(0);
            if (currentAnimatorState.IsName("Player_Fist"))
            {
                isAnimationPlaying = true;
            }
            timer += Time.deltaTime;
            yield return null;
        }

        // Assert that the Fist Attack animation is playing
        Assert.IsTrue(isAnimationPlaying, "Fist Attack animation did not play as expected.");

        // Optionally log results for debugging
        Debug.Log($"Attack Count: {attackCount}");
    }
}
