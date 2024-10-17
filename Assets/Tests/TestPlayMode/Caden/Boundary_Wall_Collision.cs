using System.Collections;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;


public class CadenS_BoundaryWallTest
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
    public IEnumerator EnemyWallTest()
    {
        yield return new WaitWhile(() => !sceneLoaded);

        // Find the Enemy and Wall in the scene
        var enemy = GameObject.Find("Enemy").GetComponent<Enemies>();
        var leftWall = GameObject.Find("WallLeft").GetComponent<BoxCollider2D>();

        float wallPositionX = leftWall.transform.position.x;

        // Set enemy's initial position near the wall (just 1 unit to the right of the wall)
        enemy.transform.position = new Vector3(wallPositionX + 2f, enemy.transform.position.y, enemy.transform.position.z);

        Debug.Log("Enemy initial position: " + enemy.transform.position.x);
        Debug.Log("Wall position: " + wallPositionX);

        yield return new WaitForSeconds(1);

        // Attempt to move past the wall 5 times
        for (int attempt = 0; attempt < 5; attempt++)
        {
            // Apply velocity to the enemy to move left
            enemy.rb.velocity = new Vector2(-10f, 0);

            // Wait for a moment to simulate movement
            yield return new WaitForSeconds(1);

            // Check if the enemy has passed the wall's X position
            float finalEnemyPositionX = enemy.transform.position.x;
            Debug.Log($"Attempt {attempt + 1}: Enemy final position: {finalEnemyPositionX}");

            // Assert that the enemy has not passed the wall (cannot go past the wall)
            Assert.GreaterOrEqual(finalEnemyPositionX, wallPositionX,
                $"Enemy should not be able to move past the wall on attempt {attempt + 1}.");

            // Reset the enemy's position for the next attempt
            enemy.transform.position = new Vector3(wallPositionX + 1f, enemy.transform.position.y, enemy.transform.position.z);
        }

        yield return null; // Ensure the test completes
    }
}
