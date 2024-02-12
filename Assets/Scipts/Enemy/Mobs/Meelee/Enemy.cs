using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    // public GameObject damageEffect;
    // public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        // Instantiate(damageEffect, transform.position, Quaternion.identity)
        health -= damage;
        Debug.Log("Damage Taken !");
    }
}
