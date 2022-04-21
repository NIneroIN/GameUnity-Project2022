using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : Enemy
{
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public override void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            Death();
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    public override float GetHealth() => currentHealth;

    public override float GetMaxHealth() => maxHealth;
}
