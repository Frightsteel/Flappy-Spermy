using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public GameManager gameManager;

    public TextMeshProUGUI inGameScoreText;
    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI gameOverBestScoreText;

    public int score = 0;
    public int bestScore;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("bestScore");
    }

    public void SaveScore()
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }
    }

    public void UpdateScore()
    {
        score++;
        inGameScoreText.text = score.ToString();
    }

    public void UpdateScoreText() 
    {
        SaveScore();
        
        gameOverScoreText.text = score.ToString();
        gameOverBestScoreText.text = bestScore.ToString();
    }
}
