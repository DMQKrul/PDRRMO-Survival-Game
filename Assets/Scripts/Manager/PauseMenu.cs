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
    public GameObject blurBg;
    public GameObject blurBg2;
    public GameObject blurBg3;
    public GameObject menuConfirm;
    public GameObject quitConfirm;

    public void Pause()
    {
        PausePanel.SetActive(true);
        blurBg.SetActive(true);
        healthBar.SetActive(false);
        pauseBtn.SetActive(false);
        controls.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        PausePanel.SetActive(false);
        blurBg.SetActive(false);
        healthBar.SetActive(true);
        pauseBtn.SetActive(true);
        controls.SetActive(true);
        Time.timeScale = 1f;
    }

    public void GoBack()
    {
        menuConfirm.SetActive(true);
        blurBg2.SetActive(true);
    }

    public void GoBackToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void NoMenu()
    {
        menuConfirm.SetActive(false);
        blurBg2.SetActive(false);
    }

    public void Exit()
    {
        quitConfirm.SetActive(true);
        blurBg3.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NoQuit()
    {
        quitConfirm.SetActive(false);
        blurBg3.SetActive(false);
    }
}
