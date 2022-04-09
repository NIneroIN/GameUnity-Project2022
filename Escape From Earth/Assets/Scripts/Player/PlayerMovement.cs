using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public bool isFacingRight = true;
    public float horizontalAxis;

    public float jumpForce;
    public float increaseJumpForce;
    public int extraJump;
    public int countJump;
    public bool isGrounded;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Прыжок
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                extraJump = countJump;
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
        if (!isGrounded && extraJump > 0 && Input.GetKeyDown(KeyCode.W))
        {
            --extraJump;
            //rb.velocity = new Vector2(rb.velocity.x, increaseJumpForce);
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, increaseJumpForce), ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {
        // Перемещение игрока по горизонтали
        horizontalAxis = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalAxis * speed, rb.velocity.y);

        // Поворот персонажа
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (direction.x > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (direction.x < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }
}
