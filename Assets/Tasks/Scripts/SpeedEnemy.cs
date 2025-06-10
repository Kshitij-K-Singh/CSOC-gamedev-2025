using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEnemy : Enemy
{
    public float dashDistance = 10f; // Distance to dash Away from the player
    // public float dashCooldown = 2f; // Cooldown time for dashing
    // private float lastDashTime = -Mathf.Infinity; // Time when the enemy last dashed
    public override void Attack()
    {
        if (player != null && !playerhidden && Vector2.Distance(transform.position, player.transform.position) <= attackRange)
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                player.GetComponent<PlayerScript>().TakeDamage(playerDamage);
                lastAttackTime = Time.time;
                DashOut();
            }
        }
    }
    private void DashOut()
    {
        Vector2 directionAway = (transform.position - player.transform.position).normalized;
        Vector2 dashTarget = (Vector2)transform.position + directionAway * dashDistance;
        transform.position = dashTarget;
    }
}
