using System.Collections;
using System.Collections.Generic;
using LootLocker.Requests;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public GameManager gameManager;

    public TextMeshProUGUI inGameScoreText;
    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI gameOverBestScoreText;

    public int score = 0;
    public int bestScore = 0;

    private void Start()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            //Debug.Log("parasha");
        }
        bestScore = PlayerPrefs.GetInt("BestScore");
        //Debug.Log(bestScore);
    }

    public void SaveScore()
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
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
