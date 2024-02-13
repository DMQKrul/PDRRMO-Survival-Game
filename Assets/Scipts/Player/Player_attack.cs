using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_attack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    private Animator playerAnim;
    public float attackRange;
    public int damage;

    // Reference to the UI button
    public Button attackButton;

    void Start()
    {
        // Register a method to be called when the button is clicked
        playerAnim = GetComponent<Animator>();
        attackButton.onClick.AddListener(Attack);
    }

    void Update()
    {
        if (timeBtwAttack > 0)
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        if (timeBtwAttack <= 0)
        {
            // camAnim.SetTrigger("shake");
            playerAnim.SetBool("isAttacking", true);
            playerAnim.SetBool("isAtkRunning", true);
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
            }

            timeBtwAttack = startTimeBtwAttack;
        }
    }

    public void endAttack()
    {
        playerAnim.SetBool("isAttacking", false);
        playerAnim.SetBool("isAtkRunning", false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
