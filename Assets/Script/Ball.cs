using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform paddle;
    public float MaxVelocity = 10;

    private static bool isPlaying = false;
    private CircleCollider2D cCollider;

    // Use this for initialization
    void Start()
    {
        cCollider = GetComponent<CircleCollider2D>();
    }

    void FixedUpdate()
    {
        if(!isPlaying)
        {
            cCollider.attachedRigidbody.isKinematic = true;
        }

        if ((Input.touchCount > 0 || Input.GetKeyUp(KeyCode.Space)) && !isPlaying)
        {
            cCollider.attachedRigidbody.isKinematic = false;
            isPlaying = !isPlaying;
            cCollider.attachedRigidbody.AddForce(new Vector3(Random.Range(-5, 6), 5, 0), ForceMode2D.Impulse);
        }

        cCollider.attachedRigidbody.velocity = Vector2.ClampMagnitude(cCollider.attachedRigidbody.velocity, MaxVelocity);
    }

    public void ResetBall()
    {
        cCollider.attachedRigidbody.velocity = new Vector2(0, 0);
        cCollider.attachedRigidbody.angularVelocity = 0f;
        gameObject.transform.position = new Vector3(paddle.transform.position.x + 0.6f, paddle.transform.position.y + 1f, 0);
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        isPlaying = false;
    }

    public bool IsPLaying()
    {
        return isPlaying;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rigidBody = cCollider.attachedRigidbody;

        Vector2 tweak = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));

        rigidBody.velocity += tweak;
        rigidBody.AddForce(rigidBody.velocity * 0.1f, ForceMode2D.Impulse);
    }
}