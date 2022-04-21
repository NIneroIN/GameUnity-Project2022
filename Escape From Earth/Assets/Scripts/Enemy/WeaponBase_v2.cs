using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase_v2 : MonoBehaviour
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
        for (float i=-40; i <= 40; i+=20)
        {
            Vector2 ray = transform.right;
            RaycastHit2D hit = Physics2D.Raycast(eyes.position, ray, playerDistance);
            if (hit)
            {
                pl = hit.transform.GetComponent<PlayerBase>();
                if (pl != null)
                {
                    transform.rotation = Quaternion.Euler(0, 0, i);
                    isEyes = true;
                }
            }
            else
            {
                isEyes = false;
            }
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
