using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    public int rows = 5;
    public int cols = 5;

    public GameObject Block;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                GameObject.Instantiate(Block, new Vector3(-5.8f + (5.8f * i), 4 * j, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
