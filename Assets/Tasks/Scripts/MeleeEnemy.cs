using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public override void Attack()
    {
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
