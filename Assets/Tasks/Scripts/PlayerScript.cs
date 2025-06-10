using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerScript : MonoBehaviour
{
    public bool isStealth = false; // Variable to check if the player is in stealth mode
    public static Action OnPlayerDeath;
    public int maxhealth = 100;
    public HealthBar healthBar;
    public int currentHealth;
    public float horizontal;
    public float vertical;
    public Camera cam;
    private float moveSpeed = 8f;
    private float jumpingPower = 20f;
    private bool isFacingRight = true;
    private bool canDash = true;
    bool isDashing = false;
    public Transform tr;
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer trr;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {

        currentHealth = maxhealth;
        healthBar.SetMaxHealth(maxhealth);
    }
    void Update()
    {

        if (isDashing)
        {
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = transform.position.y;
        if (vertical <= -15)
        {
            SceneManager.LoadScene(1);
        }


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(new Vector2(0f, jumpingPower), ForceMode2D.Impulse);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }



        Flip();
    }
    private void FixedUpdate()
    {

        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1f;
            transform.localScale = theScale;
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float OriginalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        trr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        trr.emitting = false;
        isDashing = false;
        rb.gravityScale = OriginalGravity;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        // Handle player death (e.g., reload scene, show game over screen)
        Debug.Log("You died.");
        Destroy(gameObject); // Destroy the player object
        Time.timeScale = 0f; // Pause the game
        OnPlayerDeath?.Invoke();
    }

    public void EnterStealthMode()
    {
        isStealth = true;
    }
    public void ExitStealthMode()
    {
        isStealth = false;
    }
}
