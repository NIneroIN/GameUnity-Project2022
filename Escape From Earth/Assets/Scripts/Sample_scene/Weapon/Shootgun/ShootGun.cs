using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootGun : MonoBehaviour
{
    public GameObject ammo;
    public int maxAmmo;
    public int ammoCount;

    public Transform shootDir;

    public float reloadTime;
    public bool isReload;

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

    void Update()
    {
        // Поворот с оружием
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotateZ);
        if (Mathf.Abs(rotateZ) > 90)
            transform.Rotate(180, 0, 0);

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

        if (Input.GetKeyDown(KeyCode.R) && ammoCount < maxAmmo && !isReload)
        {
            isReload = true;
            StartCoroutine(Reload());
        }

        ammoText.text = ammoCount + " / " + maxAmmo;
        if (isReload) ammoText.text += " : R";
    }

    public IEnumerator Reload()
    {
        int reason = maxAmmo - ammoCount;
        for (int i = 0; i < reason; i++)
        {
            yield return new WaitForSeconds(reloadTime / 10);
            ammoCount += 1;
        }
        isReload = false;
    }
}
