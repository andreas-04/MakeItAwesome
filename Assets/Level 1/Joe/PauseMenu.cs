using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButtonManager : MonoBehaviour
{
    public Button pauseButton;
    public GameObject pauseMenu;    // The Pause Menu panel
    // public GameObject controlsMenu; // The Controls Menu panel
    public Button resumeButton;     // Resume Button
    public Button controlsButton;   // Controls Button
    public Button quitButton;       // Quit Button
    // public Button backButton;       // Back button from the Controls menu

    private bool isPaused = false;

    void Start()
    {
        // Initially hide the pause menu and controls menu
        pauseMenu.SetActive(false);
        // controlsMenu.SetActive(false);

        pauseButton.onClick.AddListener(TogglePause);

        // Hook up button listeners
        resumeButton.onClick.AddListener(ResumeGame);
        // controlsButton.onClick.AddListener(ShowControlsMenu);
        quitButton.onClick.AddListener(QuitToTitle);
        // backButton.onClick.AddListener(ShowPauseMenu);
    }

    // This method should be called when the Pause button is clicked
    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    // Pauses the game and shows the pause menu
    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Freezes the game time
        pauseMenu.SetActive(true); // Shows the pause menu
        // controlsMenu.SetActive(false); // Ensure control menu is hidden
    }

    // Resumes the game and hides the pause menu
    private void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resumes normal time
        pauseMenu.SetActive(false); // Hides the pause menu
        // controlsMenu.SetActive(false); // Hides the controls menu if it was open
    }

    // Shows the Controls Menu
    private void ShowControlsMenu()
    {
        pauseMenu.SetActive(false); // Hide the pause menu
        // controlsMenu.SetActive(true); // Show the controls menu
    }

    // Back to the Pause Menu from Controls Menu
    private void ShowPauseMenu()
    {
        // controlsMenu.SetActive(false); // Hide the controls menu
        pauseMenu.SetActive(true); // Show the pause menu
    }

    // Quits to the title screen
    private void QuitToTitle()
    {
        Time.timeScale = 1f; // Ensure time is resumed before switching scenes
        SceneManager.LoadScene("TitleScreen"); // Replace with your actual title screen scene name
    }
}
