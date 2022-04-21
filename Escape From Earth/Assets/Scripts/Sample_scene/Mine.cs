using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public GameObject explosion;
    public Transform shootDir;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(explosion, shootDir.position, explosion.transform.rotation);
        Destroy(gameObject);
    }
}
