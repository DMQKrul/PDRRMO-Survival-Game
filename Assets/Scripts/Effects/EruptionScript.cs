using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EruptionScript : MonoBehaviour
{
    private GameObject target;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    public float damage;
    private CamShake shake;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Target");
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CamShake>();

        Vector3 direction = target.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + -90);

        // if (rb != null)
        // {
        //     rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        // }
        
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
        if (other.gameObject.CompareTag("Target"))
        {
            shake.CamShaking();
            other.gameObject.GetComponent<Character>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
