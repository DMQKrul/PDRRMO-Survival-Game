using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private Animator enemyAtkAnim;

    private float timer;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyAtkAnim = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position,player.transform.position);

        if(distance < 10)
        {
            timer += Time.deltaTime;

             if(timer > 4)
             {
                timer = 0;
                enemyAtkAnim.SetBool("isAttacking", true);
                shoot();
             }
        }
    }

    void shoot()
    {        
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    public void stopShooting()
    {
        enemyAtkAnim.SetBool("isAttacking", false);
    }
}
