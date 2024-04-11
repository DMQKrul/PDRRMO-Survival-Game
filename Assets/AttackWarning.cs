using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWarning : MonoBehaviour
{
    [SerializeField] private GameObject warningIndicator;
    [SerializeField] private float warningDuration = 1f;

    private Coroutine warningCoroutine;

    public void StartWarning()
    {
        if (warningCoroutine != null)
        {
            StopCoroutine(warningCoroutine);
        }
        Time.timeScale = 0f;
        warningCoroutine = StartCoroutine(ShowWarning());
    }

    private IEnumerator ShowWarning()
    {
        warningIndicator.SetActive(true);
        yield return new WaitForSecondsRealtime(warningDuration);
        warningIndicator.SetActive(false);
        Time.timeScale = 1f;
    }
}
