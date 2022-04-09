using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                door.SetActive(false);
            }
        }
    }
}
