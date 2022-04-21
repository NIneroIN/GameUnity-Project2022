using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;

    public int positionOfPatrol;
    public Transform point;
    bool movingRight = true;

    Transform player;
    public float stoppingDistance;

    bool angry = false;
    bool goBack = false;
    bool calm = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && !angry)
        {
            calm = true;
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;
        }

        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            calm = false;
            goBack = false;
        }

        if (calm)
            Calm();
        else if (angry)
            Angry();
        else if (goBack)
            GoBack();
    }

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        speed = 4;
    }

    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        speed = 2;
    }

    void Calm()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            movingRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            movingRight = true;
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
}
