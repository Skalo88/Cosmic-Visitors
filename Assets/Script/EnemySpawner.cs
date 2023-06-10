using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;  // Interval between enemy spawns
    public int maxEnemies = 20;  // Maximum number of enemies to spawn
    public float minX = -5f;  // Minimum X position for spawning enemies
    public float maxX = 5f;  // Maximum X position for spawning enemies
    public float minY = 4.3f;  // Minimum Y position for spawning enemies
    public float maxY = 6f;  // Maximum Y position for spawning enemies

    private float timer = 0f;  // Timer to track spawn intervals
    private int currentEnemies = 0;  // Number of currently spawned enemies

    private void Start()
    {
        // Start spawning enemies
        StartSpawning();
    }

    private void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if it's time to spawn a new enemy
        if (timer >= spawnInterval && currentEnemies < maxEnemies)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    private void StartSpawning()
    {
        // Reset the current enemy count
        currentEnemies = 0;
    }

    private void SpawnEnemy()
    {
        // Generate a random position within the specified range
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

        // Instantiate the enemy prefab at the spawn position
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Increase the current enemy count
        currentEnemies++;
    }
}
