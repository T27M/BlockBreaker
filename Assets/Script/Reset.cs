using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameManager gm;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Reset");

        CircleCollider2D ball = collision.GetComponent<CircleCollider2D>();

        if (ball != null)
        {
            if (ball.gameObject.CompareTag("Ball"))
            {
                ball.GetComponent<Ball>().ResetBall();
                gm.LoseLife();
            }
        }
    }
}