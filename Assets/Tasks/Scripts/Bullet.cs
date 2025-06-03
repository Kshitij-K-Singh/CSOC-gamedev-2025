using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject HitEffect;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.42f);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.42f);
            Destroy(gameObject);
        }
    }
}
