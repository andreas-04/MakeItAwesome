using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;


public class JOE_TitleScreenPlayModeTests
{
    private bool sceneLoaded;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadScene("Scenes/TitleScreen", LoadSceneMode.Single);
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        sceneLoaded = true;
    }

    [UnityTest]
    public IEnumerator StartButtonExists()
    {
        yield return new WaitWhile(() => sceneLoaded == false);
        GameObject startButton = GameObject.Find("Start");
        Assert.IsNotNull(startButton, "Start button not found in the scene");
        yield return null;
    }

    [UnityTest]
    public IEnumerator StartButtonLoadsGameScene()
    {
        yield return new WaitWhile(() => sceneLoaded == false);
        GameObject startButton = GameObject.Find("Start");
        Assert.IsNotNull(startButton, "Start button not found in the scene");

        // Click the start button
        startButton.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        // Wait for the scene to load
        yield return new WaitForSeconds(1);

        // Check if the active scene is the game scene
        Assert.AreEqual("ChaniT", SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator ControlsButtonExists()
    {
        yield return new WaitWhile(() => sceneLoaded == false);
        GameObject controls = GameObject.Find("Controls");
        Assert.IsNotNull(controls, "controls button not found in the scene");
        yield return null;
    }

    [UnityTest]
    public IEnumerator ControlsButtonActivatesControlsPanel()
    {
        yield return new WaitWhile(() => sceneLoaded == false);
        GameObject controlsButton = GameObject.Find("Controls");
        Assert.IsNotNull(controlsButton, "Controls button not found in the scene");

        // Click the controls button
        controlsButton.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        // Wait for the scene to load
        yield return new WaitForSeconds(1);

        GameObject backButton = GameObject.Find("BackButton");
        Assert.IsNotNull(backButton, "Back button not found in the scene after activating the controls panel");
        // Wait for a frame to allow the UI to update
        yield return null;
    }

    [UnityTest]
    public IEnumerator ExitButtonExists()
    {
        yield return new WaitWhile(() => sceneLoaded == false);
        GameObject exit = GameObject.Find("Exit");
        Assert.IsNotNull(exit, "Exit button not found in the scene");
        yield return null;
    }

    [UnityTest]
    public IEnumerator ExitExits()
    {
        yield return new WaitWhile(() => sceneLoaded == false);
        GameObject exitButton = GameObject.Find("Exit");
        Assert.IsNotNull(exitButton, "Exit button not found in the scene");

        // Click the exit button
        exitButton.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();


        // Wait for the scene to load
        yield return new WaitForSeconds(1);

        // Clear any existing logs
        LogAssert.ignoreFailingMessages = true;
        LogAssert.Expect(LogType.Log, "Game exited");

        yield return null;
    }

    [UnityTest]
    public IEnumerator ControlsButtonThenBackButtonDeactivatesControlsPanel()
    {
        yield return new WaitWhile(() => sceneLoaded == false);
        GameObject controlsButton = GameObject.Find("Controls");
        Assert.IsNotNull(controlsButton, "Controls button not found in the scene");

        // Click the controls button
        controlsButton.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        yield return new WaitForSeconds(1);

        GameObject controlsPanel = GameObject.Find("ControlsPanel");
        Assert.IsNotNull(controlsPanel, "Controls panel not found in the scene");

        // Check if the controls panel is now active
        Assert.IsTrue(controlsPanel.activeSelf, "Controls panel is not active after clicking the controls button");

        // Check if the back button exists
        GameObject backButton = GameObject.Find("BackButton");
        Assert.IsNotNull(backButton, "Back button not found in the scene after activating the controls panel");

        // Click the back button
        backButton.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        yield return new WaitForSeconds(1);

        // Check if the controls panel is now inactive
        Assert.IsFalse(controlsPanel.activeSelf, "Controls panel is still active after clicking the back button");
    }
}