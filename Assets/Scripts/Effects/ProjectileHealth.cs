using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHealth : MonoBehaviour
{
    public float healthMax;
    public float health = 1;


    void Start()
    {
        healthMax = health;
    }

    public void TakeDamage(float damage)
    {
        healthMax -= damage;

        if (healthMax <= 0)
        {
            Destroy(gameObject);
        }
    }
}
