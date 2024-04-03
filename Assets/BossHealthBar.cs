using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public MobHealth bossHealth;
    public Image fillImage;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value <= slider.minValue)
            {
                fillImage.enabled = false;
            }

        if(slider.value > slider.minValue && !(fillImage))
            {
                fillImage.enabled = true;
            }   


        float fillValue = bossHealth.healthMax / bossHealth.health;
        slider.value = fillValue;
    }
}
