using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsShootgun : MonoBehaviour
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
        foreach (Transform ammo in transform)
        {
            ammo.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}
