using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    public GameObject mainMenuPanel;
    public GameObject scoreText;
    public GameObject gameOverScoreText;
    public GameObject gameOverBestScoreText;
    public GameObject gameOverPanel;
    
    public void StartButton()
    {
        mainMenuPanel.SetActive(false);
        gameManager.StartGame();
        scoreText.SetActive(true);
    }

    public void ScoreTextUpdate(int score)
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }

    public void GameOverMenuOpen(int score)
    {
        gameManager.SaveScore(score);
        gameOverScoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
        gameOverBestScoreText.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("bestScore").ToString();
        gameOverPanel.SetActive(true);
    }
}
