using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("health")]
    public float maxHealth = 10;
    public float currentHealth;

    public abstract void TakeDamage(float damage);

    public abstract float GetHealth();

    public abstract float GetMaxHealth();
}
