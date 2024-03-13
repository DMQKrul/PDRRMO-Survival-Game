using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float countdown;
    [SerializeField] private GameObject[] spawnPoints;

    public Wave[] waves;
    public int currentWaveIndex = 0;
    private bool readyToCountdown;

    private void Start()
    {
        readyToCountdown = true;
        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].enemiesLeft = waves[i].enemies.Length;
        }
    }

    private void Update()
    {
        if (currentWaveIndex >= waves.Length)
        {
            Debug.Log("You survived every wave");
            return;
        }
        if (readyToCountdown == true)
        {
            countdown -= Time.deltaTime;
        }
        if (countdown <= 0)
        {
            readyToCountdown = false;
            countdown = waves[currentWaveIndex].timeToNextWave;
            StartCoroutine(SpawnWave());
        }

        if (waves[currentWaveIndex].enemiesLeft == 0)
        {
            readyToCountdown = true;
            currentWaveIndex++;
        }
    }


  private IEnumerator SpawnWave()
    {
        if (currentWaveIndex < waves.Length)
        {
            Wave currentWave = waves[currentWaveIndex];

            for (int i = 0; i < currentWave.enemies.Length; i++)
            {
                // Randomly select a spawn point
                GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                // Instantiate enemy at the selected spawn point
                MobHealth enemy = Instantiate(currentWave.enemies[i], spawnPoint.transform.position, Quaternion.identity);
                enemy.transform.SetParent(spawnPoint.transform);

                yield return new WaitForSeconds(currentWave.timeToNextEnemy);
            }
        }
    }
    
}

[System.Serializable]
public class Wave
{
     public MobHealth[] enemies;
     public float timeToNextEnemy;
     public float timeToNextWave;

     [HideInInspector] public int enemiesLeft;
}
