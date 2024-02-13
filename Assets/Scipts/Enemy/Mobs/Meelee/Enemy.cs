using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    private float dazedTime;
    public float startDazedTime;
    public float speed;
    // public GameObject damageEffect;
    // public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        if(dazedTime <= 0)
        {
            speed = 2;
        } else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        // Instantiate(damageEffect, transform.position, Quaternion.identity)
        health -= damage;
        Debug.Log("Damage Taken !");
    }
}
