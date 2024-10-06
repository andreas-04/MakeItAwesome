using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    public int playerHealth  = 100

    public List<Collectible> inventory = new List<Collectible>();

    public string currentObjective;

    private void Awake()
    {
        // Ensure there's only one instance of GameManager (Singleton pattern)
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManager instances
        }
    }
    
    public void AddToInventory(Collectible item)
    {
        inventory.Add(item);
        Debug.Log(item.name + " added to inventory.");
    }
    public void UpdateObjective(string newObjective)
    {
        currentObjective = newObjective;
        Debug.Log("Objective updated: " + currentObjective);
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        // Add game over logic here (e.g., show Game Over screen, restart level)
    }
}
