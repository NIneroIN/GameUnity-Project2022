using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public GameObject ammo;
    public int maxAmmo;
    private int ammoCount;
    public Transform shootDir;
    public Transform eyes;
    public bool isEyes;

    public bool isReload = false;
    public float reloadTime;

    private float shootTime;
    public float shootStartTime;


    public float playerDistance;
    PlayerBase pl;

    void Start()
    {
        ammoCount = maxAmmo;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(eyes.position, transform.right, playerDistance);
        
        if (hit)
        {
            pl = hit.transform.GetComponent<PlayerBase>();
            if (pl != null)
            {
                isEyes = true;
            }
        }
        else
        {
            isEyes = false;
        }

        // Выстрел
        if (isEyes)
        {
            Angry();
        }
    }

    void Angry()
    {
        if (ammoCount > 0 && !isReload)
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

        if (!isReload && ammoCount == 0)
        {
            isReload = true;
            Invoke("Reload", reloadTime);
        }
    }


    public void Reload()
    {
        if (isReload)
        {
            ammoCount = maxAmmo;
            isReload = false;
        }
    }
}
