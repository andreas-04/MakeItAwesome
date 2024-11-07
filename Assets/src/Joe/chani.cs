using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    // References to the UI Buttons
    public Button continueButton;
    public Button runButton;

    void Start()
    {
        // Add listeners to the buttons
        continueButton.onClick.AddListener(OnContinueButtonClick);
        runButton.onClick.AddListener(OnRunButtonClick);
    }

    // Method called when the Continue button is clicked
    void OnContinueButtonClick()
    {
        Debug.Log("Continue button clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Method called when the Run button is clicked
    void OnRunButtonClick()
    {
        Debug.Log("Run button clicked");
        SceneManager.LoadScene("Scenes/End");
    }
}
