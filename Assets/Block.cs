using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private static Vector3 offScreen = new Vector3(100, 100, 0);

    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.attachedRigidbody.AddForce(collision.collider.attachedRigidbody.velocity * 0.1f, ForceMode2D.Impulse);

        Debug.Log("Collide");
        this.transform.position = offScreen;
    }
}
