using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
