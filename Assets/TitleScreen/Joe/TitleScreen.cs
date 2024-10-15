using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required for interacting with the Button component

public class TitleScreenManager : MonoBehaviour
{
    // Reference to the button (can be set in the Inspector or via code)
    public Button startButton;

    void Start()
    {
        // Hook up the StartGame method to the button's onClick event
        startButton.onClick.AddListener(StartGame);
    }

    // Method that transitions to the starting scene
    public void StartGame()
    {
        // Load the starting scene by name or index
        SceneManager.LoadScene("Level1"); // Replace with your scene's name or index
    }
}
