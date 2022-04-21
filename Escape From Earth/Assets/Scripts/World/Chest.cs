using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public bool isOpen = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (!isOpen)
            {
                Open();
                isOpen = true;
            }
        }
    }

    private void Open()
    {
        foreach (GameObject item in items)
        {
            Instantiate(item, transform.position, transform.rotation);
        }
        
    }
}
