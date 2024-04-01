using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatahSplash : MonoBehaviour
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

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + -90);
    }

    void Update()
    {
         timer += Time.deltaTime;

        if(timer > 7)
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
            Destroy(gameObject);
        }
    }
}
