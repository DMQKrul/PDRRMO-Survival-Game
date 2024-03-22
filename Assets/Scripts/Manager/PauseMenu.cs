using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject healthBar;
    public GameObject pauseBtn;
    public GameObject controls;

    public void Pause()
    {
        PausePanel.SetActive(true);
        healthBar.SetActive(false);
        pauseBtn.SetActive(false);
        controls.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        PausePanel.SetActive(false);
        healthBar.SetActive(true);
        pauseBtn.SetActive(true);
        controls.SetActive(true);
        Time.timeScale = 1f;
    }

    public void GoBack()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
