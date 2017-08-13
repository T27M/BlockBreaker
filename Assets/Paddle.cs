using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public GameObject ball;
    public Ball ballC;

    public float moveSpeed = 5.0f;

    void Start()
    {
        ballC = ball.GetComponent<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && gameObject.transform.position.x > -6.0f)
        {
            gameObject.transform.position -= new Vector3(moveSpeed, 0, 0) * Time.smoothDeltaTime;

            if (!ballC.IsPLaying())
            {
                ball.transform.position -= new Vector3(moveSpeed, 0, 0) * Time.smoothDeltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.D) && gameObject.transform.position.x < 5.0f)
        {
            gameObject.transform.position += new Vector3(moveSpeed, 0, 0) * Time.smoothDeltaTime;

            if (!ballC.IsPLaying())
            {
                ball.transform.position += new Vector3(moveSpeed, 0, 0) * Time.smoothDeltaTime;
            }
        }
    }
}