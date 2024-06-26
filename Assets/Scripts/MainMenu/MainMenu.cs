using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip btnPress;
    public float btnVolume = 1f;

    public GameObject blurBg3;
    public GameObject blurBg;
    public GameObject quitConfirm;
    public GameObject MenuBtn;
    public GameObject title;
    public GameObject selectPanel;
    public GameObject aboutPanel;
    public GameObject blurBg2;
    
    public void PlayGame()
    {
        SoundFXManager.instance.PlaySoundFXClip(btnPress, transform, btnVolume);
        selectPanel.SetActive(true);
        blurBg.SetActive(true);
        title.SetActive(false);
        MenuBtn.SetActive(false);
    }

    // public void LoadVolcano()
    // {
    //     SceneManager.LoadScene("Firelands");
    //     Time.timeScale = 1f;
    // }

    // public void LoadTsunami()
    // {
    //     SceneManager.LoadScene("Coast");
    //     Time.timeScale = 1f;
    // }
    
    // public void LoadEarthquake()
    // {
    //     SceneManager.LoadScene("City");
    //     Time.timeScale = 1f;
    // }
    
    // public void LoadTyphoon()
    // {
    //     SceneManager.LoadScene("Country Side");
    //     Time.timeScale = 1f;
    // }

    public void Back()
    {
        SoundFXManager.instance.PlaySoundFXClip(btnPress, transform, btnVolume);
        selectPanel.SetActive(false);
        blurBg.SetActive(false);
        title.SetActive(true);
        MenuBtn.SetActive(true);
    }

    public void About()
    {
        SoundFXManager.instance.PlaySoundFXClip(btnPress, transform, btnVolume);
        blurBg2.SetActive(true);
        aboutPanel.SetActive(true);
        MenuBtn.SetActive(false);
        title.SetActive(false);
    }

    public void backAbout()
    {
        SoundFXManager.instance.PlaySoundFXClip(btnPress, transform, btnVolume);
        blurBg2.SetActive(false);
        aboutPanel.SetActive(false);
        MenuBtn.SetActive(true);
        title.SetActive(true);
    }

    public void Exit()
    {
        SoundFXManager.instance.PlaySoundFXClip(btnPress, transform, btnVolume);
        quitConfirm.SetActive(true);
        title.SetActive(false);
        MenuBtn.SetActive(false);
        blurBg3.SetActive(true);
    }

    public void NoQuit()
    {
        SoundFXManager.instance.PlaySoundFXClip(btnPress, transform, btnVolume);
        quitConfirm.SetActive(false);
        title.SetActive(true);
        MenuBtn.SetActive(true);
        blurBg3.SetActive(false);
    }

    public void QuitGame()
    {
        SoundFXManager.instance.PlaySoundFXClip(btnPress, transform, btnVolume);
        Application.Quit();
    }
}
