using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButtonManager : MonoBehaviour
{
    public Button pauseButton;
    public GameObject pauseMenu;    // The Pause Menu panel
    public GameObject controlsMenu; // The Controls Menu panel
    public Button resumeButton;     // Resume Button
    public Button controlsButton;   // Controls Button
    public Button quitButton;       // Quit Button
    public Button backButton;       // Back button from the Controls menu
    private bool isPaused = false;

    void Start()
    {
        // Initially hide the pause menu and controls menu
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(false);

        pauseButton.onClick.AddListener(TogglePause);

        // Hook up button listeners
        resumeButton.onClick.AddListener(ResumeGame);
        controlsButton.onClick.AddListener(ShowControlsMenu);
        quitButton.onClick.AddListener(QuitToTitle);
        backButton.onClick.AddListener(ShowPauseMenu);
    }

    void Update()
    {
        // Check if the Tab key is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TogglePause();
        }
    }

    // This method should be called when the Pause button is clicked
    public void TogglePause()
    {
        AudioManager.Instance.PlayAudio(0, 0);
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
        AudioManager.Instance.PlayAudio(0, 0);
        isPaused = true;
        Time.timeScale = 0f; // Freezes the game time
        pauseMenu.SetActive(true); // Shows the pause menu
        controlsMenu.SetActive(false); // Ensure control menu is hidden
    }

    // Resumes the game and hides the pause menu
    private void ResumeGame()
    {
        AudioManager.Instance.PlayAudio(0, 0);
        isPaused = false;
        Time.timeScale = 1f; // Resumes normal time
        pauseMenu.SetActive(false); // Hides the pause menu
        controlsMenu.SetActive(false); // Hides the controls menu if it was open
    }

    // Shows the Controls Menu
    private void ShowControlsMenu()
    {
        AudioManager.Instance.PlayAudio(0, 0);
        pauseMenu.SetActive(false); // Hide the pause menu
        controlsMenu.SetActive(true); // Show the controls menu
    }

    // Back to the Pause Menu from Controls Menu
    private void ShowPauseMenu()
    {
        AudioManager.Instance.PlayAudio(0, 0);
        controlsMenu.SetActive(false); // Hides the controls menu if it was open
        pauseMenu.SetActive(true); // Hides the pause menu
    }

    // Quits to the title screen
    private void QuitToTitle()
    {
        AudioManager.Instance.PlayAudio(0, 0);
        Time.timeScale = 1f; // Ensure time is resumed before switching scenes
        SceneManager.LoadScene("TitleScreen"); // Replace with your actual title screen scene name
    }
}
