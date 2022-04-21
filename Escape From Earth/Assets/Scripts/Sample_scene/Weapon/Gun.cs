using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject ammo;
    public int maxAmmo;
    public int ammoCount;

    public Transform shootDir;

    private float reloadTime;
    public float reloadStartTime;
    public bool isReload = false;

    private float shootTime;
    public float shootStartTime;

    [SerializeField]

    public Text ammoText;

    void Start()
    {
        ammoCount = maxAmmo;
    }
    void Update()
    {
        // Поворот с оружием
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotateZ);

        // Выстрел
        if (ammoCount > 0 && !isReload)
        {
            reloadTime = reloadStartTime;
            if (shootTime <= 0)
            {
                if (Input.GetMouseButton(0))
                {
                    Instantiate(ammo, shootDir.position, transform.rotation);
                    shootTime = shootStartTime / 10;
                    ammoCount--;
                }
            }
            else
            {
                shootTime -= Time.deltaTime;
            }
            ammoText.text = ammoCount + " / " + maxAmmo;
        }
        else if (isReload)
        {
            reloadTime -= Time.deltaTime;

            if (reloadTime <= 0)
            {
                ammoCount = maxAmmo;
                isReload = !isReload;
            }
        }  

        if (Input.GetKeyDown(KeyCode.R) && !isReload && ammoCount < maxAmmo)
        {
            isReload = !isReload;
            ammoText.text = "Reload";
        }
    }
}
