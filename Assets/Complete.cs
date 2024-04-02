using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Complete : MonoBehaviour
{
    [SerializeField] private AudioClip btnPressed;
    public float btnPressVolume = 1f;

    public GameObject StageCompletePanel;
    public GameObject healthBar;
    public GameObject pauseBtn;
    public GameObject controls;
    public GameObject blurBg;

    public void StageCompletePanelTrue()
    {
        StageCompletePanel.SetActive(true);
        healthBar.SetActive(false);
        pauseBtn.SetActive(false);
        controls.SetActive(false);
        Time.timeScale = 0f;
    }

    public void GoToMainMenu()
    {
        SoundFXManager.instance.PlaySoundFXClip(btnPressed, transform, btnPressVolume);
        SceneManager.LoadScene("MainMenu");
    }
}
