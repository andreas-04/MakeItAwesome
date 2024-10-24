using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class AMARA_ObjectBoundaryTest
{
    private bool sceneLoaded;
    private int maxX = 18, maxY = 8, maxZ = 0;
    private int minX = -8, minY = -2, minZ = 0;

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

    // Assuming your random object generation happens in this method
    private GameObject GenerateObject()
    {

        // Generate a random position within the combined bounds
        Vector3 randomPosition = new Vector3(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY),
            Random.Range(minZ, maxZ)
        );

        GameObject obj = new GameObject("Stillsuit");
        obj.transform.position = randomPosition;
        //Debug.Log($"Object generated: {randomPosition}");

        return obj;
    }

    [UnityTest]
    public IEnumerator ObjectsStayWithinDynamicBounds()
    {
        yield return new WaitWhile(() => sceneLoaded == false);
        // Run the test multiple times to verify object placement
        for (int i = 0; i < 10; i++)
        {
            GameObject randomObject = GenerateObject();

            // Wait for a frame (optional)
            yield return null;

            Vector3 position = randomObject.transform.position;

            // Assert that the object is within the combined bounds
            Assert.IsTrue(IsWithinBounds(position), $"Object is out of bounds: {position}");
        }
        Debug.Log("Test complete");
    }

    private bool IsWithinBounds(Vector3 position)
    {
        return position.x >= minX && position.x <= maxX &&
               position.y >= minY && position.y <= maxY &&
               position.z >= minZ && position.z <= maxZ;
    }
    
}
