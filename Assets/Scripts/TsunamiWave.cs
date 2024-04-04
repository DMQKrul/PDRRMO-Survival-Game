using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsunamiWave : MonoBehaviour
{
    [SerializeField] private AudioClip atkSoundClip2;
    public float atkVolume2 = 1f;

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
        SoundFXManager.instance.PlaySoundFXClip(atkSoundClip2, transform, atkVolume2);

        if (rb != null)
        {
            rb.AddForce(Vector2.left * force, ForceMode2D.Impulse);
        }
        
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
            shake.CamShaking();
            other.gameObject.GetComponent<Character>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
