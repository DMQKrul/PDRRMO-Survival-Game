using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHealth : MonoBehaviour
{
    public float healthMax;
    public float health = 50;
    private Animator animator;
    private WaveSpawner waveSpawner;
    public bool isInvulnerable = false;

    

    void Start()
    {
        animator = GetComponent<Animator>();
        // Find a component of type T in the scene
        // waveSpawner= FindObjectOfType<WaveSpawner>();
        waveSpawner = GetComponentInParent<WaveSpawner>();
        healthMax = health;
    }
    public void TakeDamage(float damage)
    {
        if (isInvulnerable)
            return;

        healthMax -= damage;
        Debug.Log("ouch");

        if (healthMax <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("Die");
    }


    private void Destroy()
    {
        Destroy(gameObject);
        waveSpawner.waves[waveSpawner.currentWaveIndex].enemiesLeft--;
    }
}
