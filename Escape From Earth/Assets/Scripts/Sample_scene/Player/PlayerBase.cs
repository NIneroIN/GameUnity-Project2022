using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [Header("health")]
    public float maxHealth = 10;
    public float protection = 2;
    public float currentHealth;
    
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage / protection;
    }

    public float GetHealth() => currentHealth;

    public float GetMaxHealth() => maxHealth;
}
