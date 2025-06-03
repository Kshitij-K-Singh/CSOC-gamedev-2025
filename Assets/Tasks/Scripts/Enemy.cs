using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Enemy : MonoBehaviour
{
    public static Action OnEnemyDeath;
    public HealthBar healthBar;
    public int health = 100;
    private int damage = 25;
    [SerializeField] public float moveSpeed = 2f;
    // Start is called before the first frame update
    [SerializeField] private GameObject player;
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
        Swarm();
    }
    private void Swarm()
    {
        PlayerScript playerScript = player.GetComponent<PlayerScript>();
        bool playerhidden = playerScript.isStealth; // Check if the player is in stealth mode
        if (player != null && !playerhidden)
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
}
