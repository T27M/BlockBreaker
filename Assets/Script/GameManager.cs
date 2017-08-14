using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Lives = 3;

    public Text livesText;

    private int activeBricks = 0;

    void Start()
    {
        livesText.text = Lives.ToString();
    }

    public void LoseLife()
    {
        if (Lives > 1)
        {
            Lives--;
            livesText.text = Lives.ToString();
        }
        else
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void AddBrick()
    {
        activeBricks++;
    }

    public void HitBrick()
    {
        activeBricks--;

        if (activeBricks == 0)
        {
            EndGame();
        }
    }
}
