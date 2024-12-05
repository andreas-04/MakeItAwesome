using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private bool hasSurvived = false;
    private int currentLevel = 0;
    private GoalItems goalItems;

    private void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;

        // Find the GoalItems script in the scene
        goalItems = FindObjectOfType<GoalItems>();
        if (goalItems == null)
        {
            Debug.LogError("GoalItems script not found in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && currentLevel == 1 && goalItems.allItemsCollected())
        {
            hasSurvived = true;
            LoadNextLevel();
        }
        else if (other.CompareTag("Player") && currentLevel != 1)
        {
            hasSurvived = true;
            LoadNextLevel();
        }
        else
        {
            Debug.Log("Cannot progress to the next level. Collect all items first!");
        }
    }

    private void LoadNextLevel()
    {
        int nextLevelIndex = currentLevel + 1;
        SceneManager.LoadScene(nextLevelIndex);
        Debug.Log("Loading next level...");
    }
}
