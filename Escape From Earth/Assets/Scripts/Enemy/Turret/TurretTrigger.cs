using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsActive(true, collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsActive(false, collision);
    }

    private void IsActive(bool isActive, Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.GetComponentInParent<Turret>().isActive = isActive;
        }
    }
}
