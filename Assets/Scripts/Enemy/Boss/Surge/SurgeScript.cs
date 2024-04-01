using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgeScript : MonoBehaviour
{
    [SerializeField] private AudioClip atkSoundClip;
    public float atkVolume = 1f;

    private Animator anim;
    public Transform bulletPos;
    public Transform tsunamiPos;
    public GameObject bullet;
    public GameObject tsunami;
    private GameObject player;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Exhausted()
    {
        anim.SetTrigger("Exhausted");
    }

    public void shoot()
    {
        SoundFXManager.instance.PlaySoundFXClip(atkSoundClip, transform, atkVolume);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    public void tsu()
    {
        Instantiate(tsunami, tsunamiPos.position, Quaternion.identity);
    }
}
