using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private static bool isPlaying = false;
    public Transform paddle;

    private CircleCollider2D cCollider;

	// Use this for initialization
	void Start () {
        cCollider = GetComponent<CircleCollider2D>();
    }
	
    void FixedUpdate()
    {
        if((Input.touchCount > 0 || Input.GetKeyUp(KeyCode.Space)) && !isPlaying)
        {
            isPlaying = !isPlaying;
            cCollider.attachedRigidbody.AddForce(Vector3.up * 100);
        }
    }

    public void ResetBall()
    {
        cCollider.attachedRigidbody.velocity = new Vector2(0, 0);
        gameObject.transform.position = new Vector3(paddle.transform.position.x + 0.6f, paddle.transform.position.y + 0.5f, 0);
        isPlaying = false;
    }

    public bool IsPLaying()
    {
        return isPlaying;
    }
}
