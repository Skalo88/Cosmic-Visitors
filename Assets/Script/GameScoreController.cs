using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScoreController : MonoBehaviour
{


    public UIController UIController;


    public GameObject GameOverPanel;

    public GameObject StartGamePanel;

    public GameObject PauseGamePanel;



    public void  Awake()
    {

    }



    private void Start() 
    {
        HideGameOver();
       // HidePausePanel();
        ShowStartGame();
    }

    public void ShowGameOver()
    {
        GameOverPanel.SetActive(true);
    }

    public void HideGameOver()
    {
        GameOverPanel.SetActive(false);
    }

    public void ShowStartGame()
    {
        StartGamePanel.SetActive(true);
    }

    public void HideStartGame()
    {
        StartGamePanel.SetActive(false);
    }

     public void ShowPausePanel()
    {
        PauseGamePanel.SetActive(true);
    }

    public void HidePausePanel()
    {
        PauseGamePanel.SetActive(false);
    } 

}
