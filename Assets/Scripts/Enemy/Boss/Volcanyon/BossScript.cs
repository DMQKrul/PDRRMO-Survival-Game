using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private Animator anim;
    public Transform bulletPos;
    public Transform eruptionPos;
    public Transform eruptionFallPos;
    public Transform eruptionFallPos2;
    public Transform eruptionFallPos3;
    public GameObject bullet;
    public GameObject eruption;
    public GameObject eruptionFall;
    public GameObject eruptionFall2;
    public GameObject eruptionFall3;
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
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
    
    public void erupt()
    {
        Instantiate(eruption, eruptionPos.position, Quaternion.identity);
    }

    public void eruptFall()
    {
        Instantiate(eruptionFall, eruptionFallPos.position, Quaternion.identity);
    }

    public void eruptFall2()
    {
        Instantiate(eruptionFall2, eruptionFallPos2.position, Quaternion.identity);
    }
    
    public void eruptFall3()
    {
        Instantiate(eruptionFall3, eruptionFallPos3.position, Quaternion.identity);
    }
}
