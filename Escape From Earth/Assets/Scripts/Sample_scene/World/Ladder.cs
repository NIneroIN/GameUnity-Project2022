using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float speed = 5f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().gravityScale = 0;
            if (Input.GetKey(KeyCode.W))
            {
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            }
            else
            {
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
