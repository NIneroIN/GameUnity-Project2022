using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rifle : MonoBehaviour
{
    public GameObject ammo;
    public int maxAmmo;
    public int ammoCount;

    public Transform shootDir;

    public bool isReload = false;
    public float reloadTime;

    private float shootTime;
    public float shootStartTime;

    [SerializeField]

    public Text ammoText;

    void Start()
    {
        ammoCount = maxAmmo;
    }

    private void OnEnable()
    {
        isReload = false;
        
    }

    private void OnDisable()
    {
        CancelInvoke();
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
        }

        if (Input.GetKeyDown(KeyCode.R) && !isReload && ammoCount < maxAmmo)
        {
            isReload = true;
            Invoke("Reload", reloadTime);
        }

        ammoText.text = ammoCount + " / " + maxAmmo;
        if (isReload) ammoText.text += " : R";
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
