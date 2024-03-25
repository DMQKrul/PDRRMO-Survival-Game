using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private AudioClip btnPressed;
    public float btnPressVolume = 1f;

    public GameObject GameOverPanel;
    public GameObject healthBar;
    public GameObject pauseBtn;
    public GameObject controls;
    public GameObject blurBg;

    public void GameOverTrue()
    {
        GameOverPanel.SetActive(true);
        healthBar.SetActive(false);
        pauseBtn.SetActive(false);
        controls.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        SoundFXManager.instance.PlaySoundFXClip(btnPressed, transform, btnPressVolume);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void GoToMainMenu()
    {
        SoundFXManager.instance.PlaySoundFXClip(btnPressed, transform, btnPressVolume);
        SceneManager.LoadScene("MainMenu");
    }
}
