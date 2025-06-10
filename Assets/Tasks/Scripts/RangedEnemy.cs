using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField] private GameObject EnemyBullet; // Reference to the bullet prefab
    public float bulletSpeed = 10f; // Speed of the bullet

    public override void Attack()
    {
        if (player != null && !playerhidden && Vector2.Distance(transform.position, player.transform.position) <= attackRange)
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                ShootBullet();
                lastAttackTime = Time.time;
            }
        }
    }

    private void ShootBullet()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        GameObject bullet = Instantiate(EnemyBullet, transform.position, rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

}
