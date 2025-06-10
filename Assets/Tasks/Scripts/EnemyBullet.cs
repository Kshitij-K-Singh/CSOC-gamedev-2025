using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int playerDamage = 10; // Damage dealt to the player when hit by the bullet
    [SerializeField] public GameObject player;
    public GameObject HitEffect;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("enemy"))
        {
            GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.42f);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
            player.GetComponent<PlayerScript>().TakeDamage(playerDamage);
            Destroy(effect, 0.42f);
            Destroy(gameObject);
        }
    }
}
