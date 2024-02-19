using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
   public GameObject cloudPrefab;
    public float spawnRate = 2f;  // Cloud spawn rate in seconds
    public float spawnRadius = 10f;  // Radius within which clouds will spawn

    private float nextSpawnTime = 0f;

    void Update()
    {
        // Check if it's time to spawn a new cloud
        if (Time.time >= nextSpawnTime)
        {
            SpawnCloud();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    void SpawnCloud()
    {
        // Generate a random position within the spawn radius
        Vector2 randomSpawnPoint = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = new Vector3(randomSpawnPoint.x, randomSpawnPoint.y, 0f);

        // Instantiate a cloud at the random position
        Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
    }
}