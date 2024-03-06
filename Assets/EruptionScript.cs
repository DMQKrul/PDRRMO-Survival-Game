using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EruptionScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    public float damage;
    public float maxRotation = 360f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (rb != null)
        {
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }

        float rot = Mathf.Atan2(-maxRotation, maxRotation) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + -180);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 5)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Character>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
