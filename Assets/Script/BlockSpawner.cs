using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    private const float spacer = 1.3f;
    public int rows = 4;
    public int cols = 5;

    public bool SpawnBlocks = true;
    public float offsetY = 4.0f;
    public float offsetX = -5.78f;
    public GameManager gm;

    public GameObject Block;

    // Use this for initialization
    void Start()
    {
        if (SpawnBlocks)
        {
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    GameObject instance = GameObject.Instantiate(Block, new Vector3(offsetX + (spacer * i), offsetY + (-spacer * j), 0), Quaternion.identity);
                    instance.GetComponent<Block>().gm = gm;
                    gm.AddBrick();
                }

            }
        }
    }
}