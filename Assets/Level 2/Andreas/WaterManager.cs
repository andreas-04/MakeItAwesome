using UnityEngine;

public class WaterManager : MonoBehaviour
{
    [SerializeField] GameObject waterPrefab;
    [SerializeField] float maxSpawnRadius = 2f;  // Maximum spawn radius to stay within grid

    private float gridWidth = 6f;
    private float gridHeight = 4f;

    public void SpawnNewWater()
    {
        // Calculate distances to the grid edges from the current water sprite position
        float distanceToLeftEdge = transform.position.x + (gridWidth / 2);
        float distanceToRightEdge = (gridWidth / 2) - transform.position.x;
        float distanceToTopEdge = (gridHeight / 2) - transform.position.y;
        float distanceToBottomEdge = transform.position.y + (gridHeight / 2);

        // Find the smallest distance to ensure the new water stays within bounds
        float spawnRadius = Mathf.Min(maxSpawnRadius, distanceToLeftEdge, distanceToRightEdge, distanceToTopEdge, distanceToBottomEdge);

        // Generate a random spawn position within this constrained radius
        Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
        Instantiate(waterPrefab, spawnPosition, Quaternion.identity);
        Destroy(gameObject);  // Destroy the old water object
    }
}
