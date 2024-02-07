using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    
    public float speed;
    public float jumpForce;

    Rigidbody2D rb;

    // Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // animator = GetComponent<Animator>();
        // animator.enabled = true;
    }

    void Update()
    {
        float movX = SimpleInput.GetAxis("Horizontal");

        rb.velocity = new Vector2(movX * speed,rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }

    public void Jump()
    {
        rb.AddForce(transform.up * jumpForce);
    }
}
