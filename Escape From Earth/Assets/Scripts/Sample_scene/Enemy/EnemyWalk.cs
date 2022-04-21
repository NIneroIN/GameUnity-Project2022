using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public float speed;

    public int positionOfPatrol;
    public Transform point;
    bool movingRight = true;
    bool isFacingRight = true;

    bool calm = false;


    private void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && !transform.GetComponentInChildren<WeaponBase>().isEyes)
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
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            movingRight = false;
            if (isFacingRight)
            {
                Flip();
            }
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            movingRight = true;
            if (!isFacingRight)
            {
                Flip();
            }
        }

        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }
}
