using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required for interacting with the Button component

public class TitleScreenManager : MonoBehaviour
{
    // Reference to the buttons (set these in the Inspector)
    public Button startButton;
    public Button controlsButton;
    public Button exitButton;
    public Button backButton;

    // Reference to the controls panel (set in the Inspector)
    public GameObject controlsPanel;

    void Start()
    {
        // Hook up the StartGame method to the start button's onClick event
        startButton.onClick.AddListener(StartGame);

        // Hook up the ShowControls method to the controls button's onClick event
        controlsButton.onClick.AddListener(ShowControls);

        // Hook up the ExitGame method to the exit button's onClick event
        exitButton.onClick.AddListener(ExitGame);

        // Hook up the BackToTitle method to the back button's onClick event in the controls panel
        backButton.onClick.AddListener(BackToTitle);

        // Ensure the controls panel is hidden at the start
        controlsPanel.SetActive(false);
    }

    // Method that transitions to the starting scene
    public void StartGame()
    {
        // Load the starting scene by name or index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(gameObject);
    }

    // Method to show the controls panel
    public void ShowControls()
    {
        // Hide the title screen and show the controls panel
        controlsPanel.SetActive(true);
    }

    // Method to go back to the title screen from the controls panel
    public void BackToTitle()
    {
        // Hide the controls panel
        controlsPanel.SetActive(false);
    }

    // Method to exit the game
    public void ExitGame()
    {
        // Quit the application
        Application.Quit();

        // If in the editor, log the quit action (since Application.Quit won't work in the editor)
#if UNITY_EDITOR
        Debug.Log("Game exited");
#endif
    }
}
