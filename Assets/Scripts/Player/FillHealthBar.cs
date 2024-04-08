using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillHealthBar : MonoBehaviour
{
    public Character playerHealth;
    public Image fillImage;
    private Slider slider;

    // Define colors for different health levels
    public Color fullHealthColor = Color.green;
    public Color lowHealthColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFillImageColor(); // Update the fill image color based on current health
        float fillValue = playerHealth.currentHealth / playerHealth.maxHealth;
        slider.value = fillValue;
    }

    // Update the fill image color based on current health
    void UpdateFillImageColor()
    {
        if (playerHealth.currentHealth <= 0)
        {
            fillImage.enabled = false;
        }
        else
        {
            fillImage.enabled = true;

            // Set color based on health level
            if (playerHealth.currentHealth <= playerHealth.maxHealth * 0.4f) // Example: If health is below 20%
            {
                fillImage.color = lowHealthColor;
            }
            else
            {
                fillImage.color = fullHealthColor;
            }
        }
    }
}