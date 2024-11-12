using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;


public class JOE_PauseMenuPlayModeTests
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
    public IEnumerator PauseResumeButtonExists()
    {
        yield return new WaitWhile(() => sceneLoaded == false);

        // Wait for the scene to load
        yield return new WaitForSeconds(2);

        // Find the PauseButton by searching for the Button component
        UnityEngine.UI.Button pauseButton = GameObject.FindObjectOfType<UnityEngine.UI.Button>(true);
        Assert.IsNotNull(pauseButton, "Pause button not found in the scene");

        // Optionally, check if the button has the correct name
        Assert.AreEqual("PauseButton", pauseButton.name, "Found button does not have the expected name");

        yield return null;
    }


}