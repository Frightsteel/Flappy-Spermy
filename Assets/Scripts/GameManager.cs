using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    internal UIManager uIManager;
    [SerializeField]
    internal SpawnManager spawnManager;
    [SerializeField]
    internal AudioManager audioManager;
    [SerializeField]
    internal LeaderboardManager leaderboardManager;
    [SerializeField]
    internal SaveManager saveManager;



    public GameObject mainCamera;
    public GameObject player;

    public int score = 0;
    public int bestScore;
    public bool isGameOver = false;
    public bool isGameOnPause = true;

    private void Start()
    {
        switch (mainCamera.GetComponent<CameraController>().isCameraMoved)
        {
            case 0:
                PauseGame();
                break;
            case 1:
                uIManager.StartButton();
                break;
        }

        bestScore = PlayerPrefs.GetInt("bestScore");


    }

    public void ScoreUpdate()
    {
        score++;
        uIManager.ScoreTextUpdate(score);
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        
        audioManager.MainThemePlay();
        
        mainCamera.GetComponent<CameraController>().CameraMove();
    }

    public void ResumeGame()
    {
        player.GetComponent<PlayerController>().RBSimulation();

        StartCoroutine(spawnManager.SpawnWalls());

        isGameOnPause = false;

        Debug.Log(mainCamera.GetComponent<CameraController>().isCameraMoved);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        //audioManager.MainThemePause();
    }

    public void SaveScore(int score)
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("isCameraMoved");
    }
}
