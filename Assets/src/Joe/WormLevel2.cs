using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene transition

public class PlayerController : MonoBehaviour
{
    public float speed = 15f; // Movement speed
    private int itemsCollected = 0; // Count of collected items
    public int totalItems = 5; // Total items to collect

    void Update()
    {
        // Player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
        transform.position += movement * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collides with an item
        if (other.gameObject.CompareTag("Collectible"))
        {
            itemsCollected++;
            Debug.Log("Items collected: " + itemsCollected);
            Destroy(other.gameObject); // Remove the collected item

            // Check if all items are collected
            if (itemsCollected >= totalItems)
            {
                GoToNextScene();
            }
        }
    }

    void GoToNextScene()
    {
        // Load the next scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
