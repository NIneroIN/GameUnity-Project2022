using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Enemy
{
    public GameObject ammo;
    public Transform shootDir;

    public int ammoCount;
    public int maxAmmo;
    public float reloadTime;

    private float shootTime;
    public float shootStartTime;

    public bool isActive;

    private void Start()
    {
        isActive = false;
        ammoCount = maxAmmo;
        currentHealth = maxHealth;
    }

    public void Update()
    {
        if (isActive)
        {
            if (ammoCount > 0)
            {
                if (shootTime <= 0)
                {
                    Instantiate(ammo, shootDir.position, transform.rotation);
                    shootTime = shootStartTime / 10;
                    ammoCount--;
                }
                else
                {
                    shootTime -= Time.deltaTime;
                }
            }
            else
            {
                Invoke("Reload", reloadTime);
            }
        }
    }

    public void Reload()
    {
         ammoCount = maxAmmo;
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
