using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float countdown;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject newSpawnPoint;
    [SerializeField] private float introDuration = 3.0f;
    [SerializeField] private Text waveCountText;

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

    public InputField nameInputField;
    public Text playerNameText;
    public GameObject returnToMain;

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
            nameInputField.gameObject.SetActive(true);
            blurBg.SetActive(true);
            healthBar.SetActive(false);
            pauseBtn.SetActive(false);
            controls.SetActive(false);
            BgMusic.SetActive(false);
            bossBar.SetActive(false);
            waveCountText.gameObject.SetActive(false);
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
            UpdateWaveCountText();
        }
    }

    private IEnumerator SpawnWave()
    {
        if (currentWaveIndex < waves.Length)
        {
            Wave currentWave = waves[currentWaveIndex];

            for (int i = 0; i < currentWave.enemies.Length; i++)
            {
                GameObject spawnPoint;

                if (currentWaveIndex == waves.Length - 1)
                {
                    spawnPoint = spawnPoints[1];
                    
                    if (i == 0)
                {
                    introObject.SetActive(true);
                    controls.SetActive(false);
                    pauseBtn.SetActive(false);
                    yield return new WaitForSeconds(introDuration);
                    introObject.SetActive(false);
                    controls.SetActive(true);
                    pauseBtn.SetActive(true);
                }
                 
                    bossBar.SetActive(true);
                }
                 else
            {
                if (i % 2 == 0)
                {
                    spawnPoint = spawnPoints[0];
                }
                else
                {
                    spawnPoint = newSpawnPoint;
                }
            }

                MobHealth enemy = Instantiate(currentWave.enemies[i], spawnPoint.transform.position, Quaternion.identity);
                enemy.transform.SetParent(spawnPoint.transform);

                yield return new WaitForSeconds(currentWave.timeToNextEnemy);
            }
        }
    }

    public void SaveAndShowName()
    {
        string playerName = nameInputField.text; // Get the player's name from the InputField
        playerNameText.text = "You did a great job " + playerName; // Display the player's name on the screen
        StartCoroutine(HideNameAfterDelay(3f)); // Call a coroutine to hide the player's name after 5 seconds
    }

    IEnumerator HideNameAfterDelay(float delay)
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(delay); // Wait for 5 seconds
        Debug.Log("Coroutine finished waiting");
        Destroy(nameInputField.gameObject);
        returnToMain.SetActive(true);
    }

    private void UpdateWaveCountText()
        {
            waveCountText.text = "Wave: " + (currentWaveIndex + 1) + "/" + waves.Length;
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
