using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_attack : MonoBehaviour
{

    [SerializeField] private AudioClip attackSoundClip;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask Enemy;
    private Animator playerAnim;
    public float attackRange;
    public float damage;

    // Reference to the UI button
    public Button attackButton;

    void Start()
    {
        // Register a method to be called when the button is clicked
        playerAnim = GetComponent<Animator>();
        attackButton.onClick.AddListener(Attack);
    }

    public void Attack()
    {
        if (timeBtwAttack <= 0)
        {
            // camAnim.SetTrigger("shake");
            playerAnim.SetBool("isAttacking", true);
            playerAnim.SetBool("isAtkRunning", true);
            SoundFXManager.instance.PlaySoundFXClip(attackSoundClip, transform, 1f);

            timeBtwAttack = startTimeBtwAttack;
        } else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    public void AttackDamage()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Enemy);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<MobHealth>().TakeDamage(damage);
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
