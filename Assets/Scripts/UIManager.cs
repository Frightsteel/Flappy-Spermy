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
    public GameObject infoText;
    
    public void StartButton()
    {
        mainMenuPanel.SetActive(false);
        gameManager.SwitchGameState(GameManager.GameState.Starting);
        
    }

    public void PauseButton()
    {
        gameManager.SwitchGameState(GameManager.GameState.Pause);
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
    }

    public void ResumeButton()
    {
        gameManager.SwitchGameState(GameManager.GameState.Playing);
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void GameOverMenuOpen()
    {
        gameManager.scoreController.UpdateScoreText();
        gameManager.leaderboardManager.SubmitScore();
        inGameUI.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void LeaderboardPanelOpen()
    {
        gameOverPanel.SetActive(false);
        leaderboardPanel.SetActive(true);
    }

    public void SwitchInGameUI()
    {
        inGameUI.SetActive(!inGameUI.activeSelf);//
        inGameUI.SetActive(true);
    }

    public void SwitchInfoText()
    {
        infoText.SetActive(!infoText.activeSelf);
    }
}
