using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            gameObject.GetComponentInParent<PlayerMovement>().isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            gameObject.GetComponentInParent<PlayerMovement>().isGrounded = false;
        }
    }
}
