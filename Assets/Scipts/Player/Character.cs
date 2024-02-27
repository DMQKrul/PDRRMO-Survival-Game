using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator playerAnim;
    public float currentHealth;
    public float maxHealth = 10;
    private float moveSpeed;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        localScale = transform.localScale;
        moveSpeed = 5f;

        currentHealth = maxHealth;
        
    }

    void Update()
    {
        //movements
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;

        if (CrossPlatformInputManager.GetButtonDown("Jump") && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * 600f);


        //animations
        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
            playerAnim.SetBool("isRunning", true);
        else 
            playerAnim.SetBool("isRunning", false);

        if (rb.velocity.y == 0)
        {
            playerAnim.SetBool("isJumping", false);
            playerAnim.SetBool("isFalling", false);
        }

        if (rb.velocity.y > 0)
            playerAnim.SetBool("isJumping", true);

        if (rb.velocity.y < 0)
        {
            playerAnim.SetBool("isJumping", false);
            playerAnim.SetBool("isFalling", true);
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        // dazedTime = startDazedTime;
        // Instantiate(damageEffect, transform.position, Quaternion.identity)
        
        Debug.Log("Damage Taken !");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    private void LateUpdate()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }
}
