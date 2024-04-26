using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private AudioClip btnPress;
    public float btnVolume = 1f;

    public GameObject PausePanel;
    public GameObject healthBar;
    public GameObject pauseBtn;
    public GameObject controls;
    public GameObject blurBg;
    public GameObject blurBg2;
    public GameObject blurBg3;
    public GameObject menuConfirm;
    public GameObject quitConfirm;
    public GameObject WaveText;

    public void Pause()
    {
        SoundFXManager.instance.PlaySoundFXClip(btnPress, transform, btnVolume);
        PausePanel.SetActive(true);
        blurBg.SetActive(true);
        WaveText.SetActive(false);
        healthBar.SetActive(false);
        pauseBtn.SetActive(false);
        controls.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        SoundFXManager.instance.PlaySoundFXClip(btnPress, transform, btnVolume);
        PausePanel.SetActive(false);
        blurBg.SetActive(false);
        WaveText.SetActive(true);
        healthBar.SetActive(true);
        pauseBtn.SetActive(true);
        controls.SetActive(true);
        Time.timeScale = 1f;
    }

    public void GoBack()
    {
        SoundFXManager.instance.PlaySoundFXClip(btnPress, transform, btnVolume);
        menuConfirm.SetActive(true);
        blurBg2.SetActive(true);
    }

    public void GoBackToMain()
    {
        SoundFXManager.instance.PlaySoundFXClip(btnPress, transform, btnVolume);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void NoMenu()
    {
        SoundFXManager.instance.PlaySoundFXClip(btnPress, transform, btnVolume);
        menuConfirm.SetActive(false);
        blurBg2.SetActive(false);
    }

    public void Exit()
    {
        SoundFXManager.instance.PlaySoundFXClip(btnPress, transform, btnVolume);
        quitConfirm.SetActive(true);
        blurBg3.SetActive(true);
    }

    public void QuitGame()
    {
        SoundFXManager.instance.PlaySoundFXClip(btnPress, transform, btnVolume);
        Application.Quit();
    }

    public void NoQuit()
    {
        SoundFXManager.instance.PlaySoundFXClip(btnPress, transform, btnVolume);
        quitConfirm.SetActive(false);
        blurBg3.SetActive(false);
    }
}
