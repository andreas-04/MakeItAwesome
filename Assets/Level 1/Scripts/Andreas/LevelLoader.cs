using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private float survivalTime = 60f;
    private float startTime;
    private bool hasSurvived = false;
    private int currentLevel = 0;

    private void Start()
    {
        startTime = Time.time;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (!hasSurvived && Time.time - startTime >= survivalTime && currentLevel == 2)
        {
            LoadNextLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && currentLevel != 2)
        {
            hasSurvived = true;
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        int nextLevelIndex = currentLevel + 1;
        SceneManager.LoadScene(nextLevelIndex);
    }
}