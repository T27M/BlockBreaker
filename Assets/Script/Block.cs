using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private static Vector3 offScreen = new Vector3(20, 20, 0);

    public GameManager gm;

    void OnCollisionEnter2D(Collision2D collision)
    {
        gm.HitBrick();
        this.transform.position = offScreen;
    }
}
