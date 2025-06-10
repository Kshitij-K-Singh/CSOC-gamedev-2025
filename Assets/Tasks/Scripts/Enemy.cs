using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Enemy : MonoBehaviour
{

    public static Action OnEnemyDeath;
    public HealthBar healthBar;
    public int health = 100;
    public int damage = 30; // Damage dealt to the enemy when attacked
    public int playerDamage = 10; // Damage dealt to the player when attacked
    public float attackRange = 1.5f;
    public float moveSpeed = 5f;
    public bool playerhidden = false;
    public float attackCooldown = 5f; // Time between attacks
    public float lastAttackTime = -Mathf.Infinity; // Time when the enemy last attacked
    // Start is called before the first frame update
    [SerializeField] public GameObject player;
    [SerializeField] private GameObject Bullet;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Bullet = GameObject.FindGameObjectWithTag("Bullet");
        healthBar.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            PlayerScript playerScript = player.GetComponent<PlayerScript>();
            playerhidden = playerScript.isStealth; // Check if the player is in stealth mode
        }
        Swarm();
        Attack();
    }
    public virtual void Swarm()
    {
        if (player != null && !playerhidden && Vector2.Distance(transform.position, player.transform.position) >= attackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            health -= damage;

            healthBar.SetHealth(health);
            if (health <= 0)
            {
                Destroy(gameObject);
                OnEnemyDeath?.Invoke();
            }
        }
    }
    public virtual void Attack()
    {
        // This method can be overridden by derived classes to implement specific attack behavior
        if (player != null && !playerhidden && Vector2.Distance(transform.position, player.transform.position) <= attackRange)
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                player.GetComponent<PlayerScript>().TakeDamage(playerDamage);
                lastAttackTime = Time.time;
            }
        }
    }

}
