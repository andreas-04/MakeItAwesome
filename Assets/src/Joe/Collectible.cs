using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Add functionality for what happens when collected
            Debug.Log("Collectible picked up by: " + other.name);

            // Destroy the collectible to make it disappear
            Destroy(gameObject);
        }
    }
}
