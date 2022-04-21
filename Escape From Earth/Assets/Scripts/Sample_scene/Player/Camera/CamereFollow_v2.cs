using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereFollow_v2 : MonoBehaviour
{
    public GameObject player; // ��� ������ ������
    private float smooth = 1f;
    private Vector3 offset= new Vector3(15, 3, -20);
    
    public float distanse;
    private Vector3 direction;

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
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        distanse = Vector3.Distance(direction, player.transform.position);
    }

    void LateUpdate()
    {
        if (player.GetComponent<PlayerMovement>().horizontalAxis > 0 && distanse < 30)
        {
            transform.position = Vector3.Lerp(transform.position, direction, Time.deltaTime * smooth);
        }
        else if (player.GetComponent<PlayerMovement>().horizontalAxis < 0)
        {
            transform.position = Vector3.Lerp(transform.position, direction + new Vector3(0, 0, -20), Time.deltaTime * smooth);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(0, offset.y, offset.z), Time.deltaTime * smooth);
        }
        
    }
}

