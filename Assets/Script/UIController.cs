using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIController : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    public List<GameObject> LifeIcons = new List<GameObject>();

    public GameObject GameOverPanel;

    public GameObject StartGamePanel;

    public GameObject PauseGamePanel;

    private void Start() 
    {
        HideGameOver();
        HidePausePanel();
        ShowStartGame();
    }

    public void UpdateScoreText(int _value)
    {
        ScoreText.text = _value.ToString();
    }

    public void UpdateLives(int _value) 
    {
       for (int i = LifeIcons.Count - 1; i >= 0; i--)
       {
            LifeIcons[i].SetActive(_value >= i);
       } 
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
