using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class AMARA_StressTest
{
    private bool sceneLoaded;
    private int numObjects = 1000;
    private float spawnTime = 1.0f;

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
    public IEnumerator AMARA_StressTestWithEnumeratorPasses()
    {
        yield return new WaitWhile(() => sceneLoaded == false);

        // Start the stopwatch
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Spawn the objects
        for (int i = 0; i < numObjects; i++)
        {
            GameObject stillsuit = new GameObject("Stillsuit");
        }

        // Stop the stopwatch
        stopwatch.Stop();

        float timeTaken = stopwatch.ElapsedMilliseconds / 1000f; // Convert to seconds
        //UnityEngine.Debug.Log($"Time taken to spawn {objectCount} objects: {timeTaken} seconds");

        // Assert that the time taken is within the acceptable limit
        Assert.LessOrEqual(timeTaken, spawnTime, $"Object spawning took too long: {timeTaken} seconds");
    }
}
