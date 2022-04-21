using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    

    void Start()
    {
        Invoke("DestroyAmmo", transform.GetComponentInParent<BulletsShootgun>().destroyTime / 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") && !collision.CompareTag("GroundDetect") && !collision.CompareTag("BulletTransparent") && !collision.CompareTag("Ammo"))
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<Enemy>().TakeDamage(transform.GetComponentInParent<BulletsShootgun>().damage);
            }
            DestroyAmmo();
        }
    }

    void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}
