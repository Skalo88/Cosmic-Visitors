using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIController : MonoBehaviour
{
    public HealthController healthController;

    bool isPaused;

    
    public Spaceship spaceship;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI PauseText;

    public GameObject GameOverPanel;

    public GameObject StartGamePanel;

    public GameObject PauseGamePanel;

    public Button QuitButton; // Reference to the quit button
    public Button resetButton; // Reference to the reset button

    


    private void Start() 
    {
        HideGameOver();
        HidePausePanel();
        ShowStartGame();

        // Add click event listeners to the buttons
        QuitButton.onClick.AddListener(QuitGame);
        resetButton.onClick.AddListener(ResetGame);
    }

    void Update()
    {
        if (healthController.playerHealth <= 0)
        {
            ShowGameOver();
        }

    if (Input.GetKeyDown(KeyCode.Escape))
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
		PauseGamePanel.SetActive(isPaused);

        if (isPaused) 
        { 
                PauseText.text = "Game Paused"; // Update the pause message text
                return;
        }
           
        else
            {
                PauseText.text = ""; // Clear the pause message text when unpausing
            }
        

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


    // Button click event handler for resetting the game
    public void ResetGame()
    {
        // Add your reset logic here
        // For example, you can reload the current scene or reset game variables

        // Call functions to reset your game here
    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;

    }



}

