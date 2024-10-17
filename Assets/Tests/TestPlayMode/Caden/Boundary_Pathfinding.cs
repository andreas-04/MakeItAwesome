using System.Collections;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;


public class CadenS_PathfindingTest
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
    public IEnumerator PathfindingTest()
    {
        yield return new WaitWhile(() => !sceneLoaded);

        // Find the Enemy and Player in the scene
        var enemies = GameObject.Find("Enemies").GetComponent<Enemies>();
        var enemy = GameObject.Find("Enemy").GetComponent<Enemies>();
        var player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        player.transform.position = new Vector3(player.transform.position.x - 4f, enemy.transform.position.y, enemy.transform.position.z);



        // Set enemy's initial position near the player
        enemy.transform.position = new Vector3(player.transform.position.x + 6f, enemy.transform.position.y, enemy.transform.position.z);

        Debug.Log("Enemy initial position: " + enemy.transform.position.x);
        Debug.Log("Player position: " + player.transform.position.x);

        yield return new WaitForSeconds(1);

        // Attempt to move towards player 5 times
        for (int attempt = 0; attempt < 5; attempt++)
        {
            

            // Wait for a moment to simulate movement
            yield return new WaitForSeconds(5);

            // Check if the enemy has passed the player's X position
            float finalEnemyPositionX = enemy.transform.position.x;
            Debug.Log($"Attempt {attempt + 1}: Enemy final position: {finalEnemyPositionX}");

            // Assert that the enemy has made it to the player
            Assert.GreaterOrEqual(finalEnemyPositionX, player.transform.position.x + 1,
                $"Enemy should have pathed to the player on {attempt + 1}.");

            // Reset the enemy's position for the next attempt
            enemy.transform.position = new Vector3(player.transform.position.x + 6f, enemy.transform.position.y, enemy.transform.position.z);
            enemies.transform.position = enemy.transform.position;
        }

        yield return null; // Ensure the test completes
    }
}
