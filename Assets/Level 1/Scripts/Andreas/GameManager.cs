using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    public int playerHealth  = 100;

    // public List<Collectible> inventory = new List<Collectible>();

    public string currentObjective = "Locate Your Stillsuit";

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
    
    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            GameOver();
        }
        Debug.Log("Player Health: " + playerHealth);
    }
     public void Heal(int health)
    {
        playerHealth += health;
        if (playerHealth >= 100)
        {
            playerHealth = 100;
        }
        Debug.Log("Player Health: " + playerHealth);
    }
    // public void AddToInventory(Collectible item)
    // {
    //     inventory.Add(item);
    //     Debug.Log(item.name + " added to inventory.");

    //     check if stillsuit fully collected (all pieces)
    //     this assumes we have to find the stillsuit first, then the rest of the items are loaded, feel free to rework
    //     UpdateObjective("Locate the rest of your supplies")

    //     if all items for level 1 collected activate level exit
    // }
    public void UpdateObjective(string newObjective)
    {
        currentObjective = newObjective;
        Debug.Log("Objective updated: " + currentObjective);
    }


    private void GameOver()
    {
        Debug.Log("Game Over!");
    }
}
