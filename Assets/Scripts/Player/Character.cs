using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
//sfx
    [SerializeField] private AudioClip jumpSoundClip;
    [SerializeField] private AudioClip walkSoundClip;

    [SerializeField] private AudioClip dmgTaken;
    public float dmgTakenVolume = 1f;

    [SerializeField] private SimpleFlash flashEffect;

    [SerializeField] private AudioClip gameOvr;
    public float gameOvrVolume = 1f;

    private Rigidbody2D rb;
    private Animator playerAnim;
    public float currentHealth;
    public float maxHealth = 10;
    private float moveSpeed;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;

    public static Character instance;

    public GameObject GameOverPanel;
    public GameObject healthBar;
    public GameObject pauseBtn;
    public GameObject controls;
    public GameObject blurBg;

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
        {
            rb.AddForce(Vector2.up * 600f);
            SoundFXManager.instance.PlaySoundFXClip(jumpSoundClip, transform, 1f);
        }
            


        //animations
        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
            {
                playerAnim.SetBool("isRunning", true);
            }
            
        else
            {
                playerAnim.SetBool("isRunning", false);
            }

        if (rb.velocity.y == 0)
        {
            playerAnim.SetBool("isJumping", false);
            playerAnim.SetBool("isFalling", false);
        }

        if (rb.velocity.y > 0)
        {
            playerAnim.SetBool("isJumping", true);
        }
        if (rb.velocity.y < 0)
        {
            playerAnim.SetBool("isJumping", false);
            playerAnim.SetBool("isFalling", true);
        }

        if (currentHealth <= 0)
        {
            Died();
        }
    }

    private void Awake()
    {
        instance = this;
    }

    void Died()
    {
        SoundFXManager.instance.PlaySoundFXClip(gameOvr, transform, gameOvrVolume);
        playerAnim.SetTrigger("Die");
    }

    private void Dead()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        // dazedTime = startDazedTime;
        // Instantiate(damageEffect, transform.position, Quaternion.identity)
        SoundFXManager.instance.PlaySoundFXClip(dmgTaken, transform, dmgTakenVolume);
        flashEffect.Flash();
        currentHealth -= damage;
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

    public void HealPlayer(int amount)
    {
        currentHealth += amount;

        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    public void GameOverTrue()
    {
        GameOverPanel.SetActive(true);
        blurBg.SetActive(true);
        healthBar.SetActive(false);
        pauseBtn.SetActive(false);
        controls.SetActive(false);
        Time.timeScale = 0f;
    }
}
