using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public int speed;
    public float damage;
    private float dazedTime;
    public Character playerHealth;

    public float startDazedTime;
    
    private Animator mob1Anim;
    

    // private Animator mobAnim;
    // public GameObject damageEffect;

    void Start()
    {
        mob1Anim = GetComponent<Animator>();
    }

    void Update()
    {

        if(dazedTime <= 0)
        {
            speed = 3;
        } else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }

        if (health <= 0)
        {
            mob1Anim.SetBool("isDead", true);
            Destroy(gameObject, 1f);
        }

        // transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if(collision.gameObject.tag == "Player")
    //         {
    //             playerHealth.TakeDamage(damage);
    //         }
    // }
    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        // Instantiate(damageEffect, transform.position, Quaternion.identity)
        health -= damage;
        Debug.Log("Damage Taken !");
        
    }
}
