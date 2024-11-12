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
        yield return new WaitForSeconds(5f);

        GameObject pause = GameObject.Find("PauseButton");

        Assert.IsNotNull(pause, "pause button not found in the scene");
        yield return null;
    }

    [UnityTest]
    public IEnumerator PauseResumeButtonClickResume()
    {
        yield return new WaitWhile(() => sceneLoaded == false);

        // Wait for the scene to load
        yield return new WaitForSeconds(5f);

        GameObject pause = GameObject.Find("PauseButton");
        // Click the start button
        pause.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        // Wait for the scene to load
        yield return new WaitForSeconds(2);

        GameObject resume = GameObject.Find("Resume");
        Assert.IsNotNull(resume, "resume button not found in the scene");
        yield return null;
    }

    [UnityTest]
    public IEnumerator PauseResumeButtonClickControls()
    {
        yield return new WaitWhile(() => sceneLoaded == false);

        // Wait for the scene to load
        yield return new WaitForSeconds(5f);

        GameObject pause = GameObject.Find("PauseButton");
        // Click the start button
        pause.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        // Wait for the scene to load
        yield return new WaitForSeconds(2);

        GameObject controls = GameObject.Find("Controls");
        Assert.IsNotNull(controls, "controls button not found in the scene");
        yield return null;
    }

    [UnityTest]
    public IEnumerator PauseResumeButtonClickQuit()
    {
        yield return new WaitWhile(() => sceneLoaded == false);

        // Wait for the scene to load
        yield return new WaitForSeconds(5f);

        GameObject pause = GameObject.Find("PauseButton");
        // Click the start button
        pause.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        // Wait for the scene to load
        yield return new WaitForSeconds(2);

        GameObject quit = GameObject.Find("Quit");
        Assert.IsNotNull(quit, "controls button not found in the scene");
        yield return null;
    }
}