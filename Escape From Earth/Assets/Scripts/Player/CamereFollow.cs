using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereFollow : MonoBehaviour
{
    public GameObject player; // тут объект игрока
    private float smooth = 1f;
    private Vector3 offset= new Vector3(15, 3, -20);

    private void Update()
    {
        if (!player.GetComponent<PlayerMovement>().isGrounded)
        {
            offset = new Vector3(15, 0, -20);
        }
        else
        {
            offset = new Vector3(15, 3, -20);
        }
    }

    void LateUpdate()
    {
        if (player.GetComponent<PlayerMovement>().horizontalAxis > 0)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, Time.deltaTime * smooth);
        }
        else if (player.GetComponent<PlayerMovement>().horizontalAxis < 0)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(-offset.x, offset.y, offset.z), Time.deltaTime * smooth);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(0, offset.y, offset.z), Time.deltaTime * smooth);
        }
        
    }
}

