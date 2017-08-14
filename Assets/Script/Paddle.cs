using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public GameObject ball;
    private Ball ballC;

    public float moveSpeed = 5.0f;
    public float MinX = -6.0f, MaxX = 5.0f;

    private bool movingLeft, movingRight;
    private float lastX = 0;
    private float curX = 0;

    void Start()
    {
        ballC = ball.GetComponent<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        curX = transform.position.x;

        if (curX < lastX)
        {
            movingRight = false;
            movingLeft = true;
        }
        else if (curX > lastX)
        {
            movingRight = true;
            movingLeft = false;
        }
        else
        {
            movingRight = false;
            movingLeft = false;
        }

        lastX = curX;

        MoveWithInput();
    }

    void MoveWithInput()
    {
        if (Input.touchCount > 0)
        {
            Vector3 touchToWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            Vector3 paddlePos = new Vector3(touchToWorld.x, this.transform.position.y, 0f);

            paddlePos.x = Mathf.Clamp(paddlePos.x, MinX, MaxX);

            this.transform.position = paddlePos;

            if (!ballC.IsPLaying())
            {
                ball.transform.position = new Vector3(paddlePos.x + 0.5f, ball.transform.position.y, 0);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (ballC.IsPLaying())
        {
            Rigidbody2D rigidBody = collision.collider.attachedRigidbody;

            if (movingLeft)
            {
                Vector2 dirLeft = Vector2.left * 5;

                rigidBody.velocity += dirLeft;
            }
            else if (movingRight)
            {
                Vector2 dirRight = Vector2.right * 5;

                rigidBody.velocity += dirRight;
            }
        }
    }
}