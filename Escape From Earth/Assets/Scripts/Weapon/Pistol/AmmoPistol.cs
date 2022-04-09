using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPistol : MonoBehaviour
{
    public float speed;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") && !collision.CompareTag("GroundDetect") && !collision.CompareTag("Ladder"))
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
