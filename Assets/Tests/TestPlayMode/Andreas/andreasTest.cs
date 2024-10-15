using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using UnityEngine.TestTools;
public class RandomSceneSwitchTest
{
    [UnityTest]
    public IEnumerator SwitchScenesEveryFrameRandomly()
    {
        int totalScenes = SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < 1000000000000; i++)
        {
            int randomSceneIndex = Random.Range(0, totalScenes);
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(randomSceneIndex);
            
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            yield return null;
        }
        Assert.Fail("nay");

    }
}