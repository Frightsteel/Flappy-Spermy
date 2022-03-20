using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    public GameObject mainMenuPanel;
    public GameObject gameOverPanel;
    public GameObject leaderboardPanel;
    public GameObject pauseButton;
    public GameObject resumeButton;
    public GameObject inGameUI;
    
    public void StartButton()
    {
        mainMenuPanel.SetActive(false);
        gameManager.StartGame();
        inGameUI.SetActive(true);
    }

    public void PauseButton()
    {
        gameManager.PauseGame();
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
    }

    public void ResumeButton()
    {
        gameManager.UnPauseGame();
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void GameOverMenuOpen()
    {
        gameManager.scoreController.UpdateScoreText();
        gameManager.leaderboardManager.SubmitScore();
        inGameUI.SetActive(false);
        gameOverPanel.SetActive(true);
        gameManager.leaderboardManager.UpdateScores();
    }

    public void LeaderboardPanelOpen()
    {
        gameOverPanel.SetActive(false);
        leaderboardPanel.SetActive(true);
    }
}
