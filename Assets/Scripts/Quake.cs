using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quake : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    public float damage;
    private CamShake shake;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CamShake>();

        if (rb != null)
        {
            rb.AddForce(Vector2.down * force, ForceMode2D.Impulse);
        }
        
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 0.4)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shake.CamShaking();
            other.gameObject.GetComponent<Character>().TakeDamage(damage);
        }
    }
}
