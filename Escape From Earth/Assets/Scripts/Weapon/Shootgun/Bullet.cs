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
        if (!collision.CompareTag("Player") && !collision.CompareTag("GroundDetect") && !collision.CompareTag("Ladder") && !collision.CompareTag("Ammo"))
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<Enemy>().TakeDamage();
            }
            DestroyAmmo();
        }
    }

    void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}
