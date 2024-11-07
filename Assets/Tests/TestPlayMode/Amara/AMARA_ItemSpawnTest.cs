using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class AMARA_ItemSpawnTest
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
    public IEnumerator AMARA_WaterSpawns()
    {
        yield return new WaitWhile(() => sceneLoaded == false);
        Assert.IsTrue(GameObject.Instantiate(Resources.Load("Assets/Items/Water") as GameObject));
    }

    [UnityTest]
    public IEnumerator AMARA_StillsuitSpawns()
    {
        yield return new WaitWhile(() => sceneLoaded == false);
        Assert.IsTrue(GameObject.Instantiate(Resources.Load("Assets/Items/Stillsuit") as GameObject));
    }

    [UnityTest]
    public IEnumerator AMARA_TentSpawns()
    {
        yield return new WaitWhile(() => sceneLoaded == false);
        Assert.IsTrue(GameObject.Instantiate(Resources.Load("Assets/Items/Tent") as GameObject));
    }

    [UnityTest]
    public IEnumerator AMARA_KnifeSpawns()
    {
        yield return new WaitWhile(() => sceneLoaded == false);
        Assert.IsTrue(GameObject.Instantiate(Resources.Load("Assets/Items/Knife") as GameObject));
    }

    [UnityTest]
    public IEnumerator AMARA_HookSpawns()
    {
        yield return new WaitWhile(() => sceneLoaded == false);
        Assert.IsTrue(GameObject.Instantiate(Resources.Load("Assets/Items/Hooks") as GameObject));
    }
}
