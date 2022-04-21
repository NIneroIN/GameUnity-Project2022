using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk_v2 : MonoBehaviour
{
    public float speed;

    public Transform point_1;
    public Transform point_2;
    bool movingRight = true;
    bool isFacingRight = true;

    bool calm = false;


    private void Update()
    {
        if (!transform.GetComponentInChildren<WeaponBase>().isEyes)
        {
            calm = true;
        }

        if (transform.GetComponentInChildren<WeaponBase>().isEyes)
        {
            calm = false;
        }

        if (calm)
            Calm();
    }

    void Calm()
    {
        if (transform.position.x >= point_2.position.x && transform.position.x > point_1.position.x)
        {
            movingRight = false;
            if (isFacingRight)
            {
                Flip();
            }
        }
        else if (transform.position.x < point_2.position.x && transform.position.x <= point_1.position.x)
        {
            movingRight = true;
            if (!isFacingRight)
            {
                Flip();
            }
        }

        if (movingRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, point_2.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, point_1.position, speed * Time.deltaTime);
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }
}
