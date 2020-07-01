using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public GameController1 controller;
    public GameObject resultPanel;
    public Text winnerText;

    //Shows Result of who won the game
    public void DisplayResult(bool winner)
    {
        Time.timeScale = 0f;
        resultPanel.SetActive(true);
        if(winner)
        {
            winnerText.text = "White Win!!!";
        }
        else if(!winner)
        {
            winnerText.text = "Black Win!!!";
        }
    }

    //Restart the current level
    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    //Goes back to the Menu
    public void Back()
    {
        Time.timeScale = 1f;
        controller.touchEnabled = true;
    }
}
