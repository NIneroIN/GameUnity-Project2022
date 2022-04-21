using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoTurret : MonoBehaviour
{
    public float speed;
    public float damage;
    public float destroyTime;

    void Start()
    {
        Invoke("DestroyAmmo", destroyTime / 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") && !collision.CompareTag("BulletTransparent"))
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerBase>().TakeDamage(damage);
            }
            DestroyAmmo();
        }
    }

    void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}
