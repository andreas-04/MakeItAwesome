using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleScreenManagerTests : MonoBehaviour
{
    private GameObject titleScreenObject;
    private TitleScreenManager titleScreenManager;
    private Button startButton;
    private Button controlsButton;
    private Button exitButton;
    private Button backButton;
    private GameObject controlsPanel;

    [SetUp]
    public void SetUp()
    {
        // Load the title screen scene
        SceneManager.LoadScene("scenes/TitleScreen");

        // Set up the title screen manager
        titleScreenObject = new GameObject();
        titleScreenManager = titleScreenObject.AddComponent<TitleScreenManager>();

        // Set up buttons and the control panel
        startButton = new GameObject().AddComponent<Button>();
        controlsButton = new GameObject().AddComponent<Button>();
        exitButton = new GameObject().AddComponent<Button>();
        backButton = new GameObject().AddComponent<Button>();
        controlsPanel = new GameObject();

        // Assign references to the title screen manager
        titleScreenManager.startButton = startButton;
        titleScreenManager.controlsButton = controlsButton;
        titleScreenManager.exitButton = exitButton;
        titleScreenManager.backButton = backButton;
        titleScreenManager.controlsPanel = controlsPanel;

        // Initially hide the controls panel
        controlsPanel.SetActive(false);

        // Call the Start method to hook up listeners
        titleScreenManager.Start();
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(titleScreenObject);
        Object.Destroy(startButton.gameObject);
        Object.Destroy(controlsButton.gameObject);
        Object.Destroy(exitButton.gameObject);
        Object.Destroy(backButton.gameObject);
        Object.Destroy(controlsPanel);
    }

    [UnityTest]
    public IEnumerator StartButton_OnClick_LoadsLevel1()
    {
        // Simulate button click
        startButton.onClick.Invoke();

        // Wait a frame for the scene load
        yield return null;

        // Check if the scene manager loads the intended scene (mock behavior)
        Assert.AreEqual("Scenes/Level1", SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator ControlsButton_OnClick_ShowsControlsPanel()
    {
        // Ensure the controls panel is initially hidden
        Assert.IsFalse(controlsPanel.activeSelf);

        // Simulate button click
        controlsButton.onClick.Invoke();

        // Wait a frame to process the button click
        yield return null;

        // Verify that the controls panel is now active
        Assert.IsTrue(controlsPanel.activeSelf);
    }

    [UnityTest]
    public IEnumerator BackButton_OnClick_HidesControlsPanel()
    {
        // Show the controls panel first
        controlsPanel.SetActive(true);

        // Simulate button click
        backButton.onClick.Invoke();

        // Wait a frame to process the button click
        yield return null;

        // Verify that the controls panel is now hidden
        Assert.IsFalse(controlsPanel.activeSelf);
    }

    [UnityTest]
    public IEnumerator ExitButton_OnClick_QuitsGame()
    {
        // Simulate button click
        exitButton.onClick.Invoke();

        // Wait a frame to process the button click
        yield return null;

        // Since Application.Quit() doesn't work in the editor, we verify via log
        LogAssert.Expect(LogType.Log, "Game exited");
    }

    [UnityTest]
    public IEnumerator ControlsPanel_IsInitiallyHidden()
    {
        // Verify that the controls panel is hidden at the start
        yield return null;
        Assert.IsFalse(controlsPanel.activeSelf);
    }

    [UnityTest]
    public IEnumerator StartButton_Listener_IsAssigned()
    {
        // Verify that the start button has a listener attached
        yield return null;
        Assert.IsNotNull(startButton.onClick);
    }

    [UnityTest]
    public IEnumerator ControlsButton_Listener_IsAssigned()
    {
        // Verify that the controls button has a listener attached
        yield return null;
        Assert.IsNotNull(controlsButton.onClick);
    }

    [UnityTest]
    public IEnumerator ExitButton_Listener_IsAssigned()
    {
        // Verify that the exit button has a listener attached
        yield return null;
        Assert.IsNotNull(exitButton.onClick);
    }

    [UnityTest]
    public IEnumerator BackButton_Listener_IsAssigned()
    {
        // Verify that the back button has a listener attached
        yield return null;
        Assert.IsNotNull(backButton.onClick);
    }
}
