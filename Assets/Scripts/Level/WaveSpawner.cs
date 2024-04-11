using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float countdown;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private float introDuration = 3.0f;

    // [SerializeField] private AudioClip Win;
    // public float WinVolume = 1f;

    public Wave[] waves;
    public int currentWaveIndex = 0;
    private bool readyToCountdown;

    public GameObject StageCompletePanel;
    public GameObject healthBar;
    public GameObject pauseBtn;
    public GameObject controls;
    public GameObject blurBg;
    public GameObject BgMusic;
    public GameObject bossBar;
    public GameObject introObject;

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
            // SoundFXManager.instance.PlaySoundFXClip(Win, transform, WinVolume);
            StageCompletePanel.SetActive(true);
            blurBg.SetActive(true);
            healthBar.SetActive(false);
            pauseBtn.SetActive(false);
            controls.SetActive(false);
            BgMusic.SetActive(false);
            bossBar.SetActive(false);
            Time.timeScale = 0f;
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
                // Select a spawn point based on the wave index
                GameObject spawnPoint;

                if (currentWaveIndex == waves.Length - 1)
                {
                    // Use a fixed spawn point for the last wave
                    spawnPoint = spawnPoints[1]; // Change this index to the desired fixed spawn point
                    
                    if (i == 0) // Only play intro once before spawning boss
                {
                    // Activate intro game object
                    introObject.SetActive(true);
                    controls.SetActive(false);
                    pauseBtn.SetActive(false);
                    yield return new WaitForSeconds(introDuration); // Wait for intro duration
                    // Deactivate intro game object
                    introObject.SetActive(false);
                    controls.SetActive(true);
                    pauseBtn.SetActive(true);
                }
                 
                    bossBar.SetActive(true);
                }
                else
                {
                    // Randomly select a spawn point for other waves
                    spawnPoint = spawnPoints[0];
                }

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
