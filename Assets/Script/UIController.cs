using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIController : MonoBehaviour
{
    public HealthController healthController;

    public TextMeshProUGUI ScoreText;

    public GameObject GameOverPanel;

    public GameObject StartGamePanel;

    public GameObject PauseGamePanel;


    private void Start() 
    {
        HideGameOver();
        HidePausePanel();
        ShowStartGame();
    }

    void Update()
    {
        if (healthController.playerHealth <= 0)
        {
            ShowGameOver();
        }
    }

    public void UpdateScoreText(int _value)
    {
        ScoreText.text = _value.ToString();
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

