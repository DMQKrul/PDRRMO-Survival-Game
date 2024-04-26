using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public GameObject WaveText;

    public InputField nameInputField;
    public Text playerNameText;
    public GameObject returnToMain;

    public void StageCompletePanelTrue()
    {
        StageCompletePanel.SetActive(true);
        nameInputField.gameObject.SetActive(true);
        healthBar.SetActive(false);
        pauseBtn.SetActive(false);
        controls.SetActive(false);
        WaveText.SetActive(false);

        Time.timeScale = 1f;
    }

    public void GoToMainMenu()
    {
        SoundFXManager.instance.PlaySoundFXClip(btnPressed, transform, btnPressVolume);
        SceneManager.LoadScene("MainMenu");
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
        playerNameText.text = ""; // Clear the player's name from the screen
        nameInputField.gameObject.SetActive(false);
        returnToMain.SetActive(true);
    }
}
