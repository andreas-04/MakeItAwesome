using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class JOE_TEST_Chani
{
    private bool sceneLoaded;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        sceneLoaded = true;
    }

    [SetUp]
    public void SetUp()
    {
        sceneLoaded = false;
        SceneManager.LoadScene("Scenes/ChaniT", LoadSceneMode.Single);
    }


    [UnityTest]
    public IEnumerator ContinueButtonExists()
    {
        yield return new WaitWhile(() => sceneLoaded == false);
        GameObject conti = GameObject.Find("Continue");
        Assert.IsNotNull(conti, "Start button not found in the scene");
        yield return null;
    }

    [UnityTest]
    public IEnumerator RunButtonExists()
    {
        yield return new WaitWhile(() => sceneLoaded == false);
        GameObject run = GameObject.Find("Run");
        Assert.IsNotNull(run, "Start button not found in the scene");
        yield return null;
    }

    [UnityTest]
    public IEnumerator ContinueButtonLoadsGameScene()
    {
        yield return new WaitWhile(() => sceneLoaded == false);
        GameObject conti = GameObject.Find("Continue");

        // Click the start button
        conti.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        // Wait for the scene to load
        yield return new WaitForSeconds(1);

        Assert.AreEqual("Level1", SceneManager.GetActiveScene().name);
        yield return null;
    }

    [UnityTest]
    public IEnumerator RunButtonLoadsGameScene()
    {
        yield return new WaitWhile(() => sceneLoaded == false);
        GameObject run = GameObject.Find("Run");
        Assert.IsNotNull(run, "run button not found in the scene");

        // Click the start button
        run.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        // Wait for the scene to load
        yield return new WaitForSeconds(2);

        Assert.AreEqual("End", SceneManager.GetActiveScene().name);
        yield return null;
    }

}
