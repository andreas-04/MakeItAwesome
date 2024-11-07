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
    private float frameRate = Time.frameCount / Time.time;
    private GameObject Stillsuit;
    private bool frameDrop = false;
    private int itemsSpawned = 0;

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
    public IEnumerator AMARA_ObjectStressTest()
    {
        yield return new WaitWhile(() => sceneLoaded == false);
        //var item = GameObject.Find("Stillsuit");

        // Spawn the objects
        for(int i = 0; i < 1000000000000000; i++) {
            GameObject.Instantiate(Resources.Load("Assets/Items/Stillsuit") as GameObject);
            itemsSpawned++;
            UnityEngine.Debug.Log("fps: " + frameRate + " items in game: " + itemsSpawned);
            if(frameRate < 20) {
                frameDrop = true;
            }
        }
        Assert.IsFalse(frameDrop, "Fps dropped below 20");
    }
}
