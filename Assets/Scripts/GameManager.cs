using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager uIManager;
    public SpawnManager spawnManager;
    public AudioManager audioManager;
    public LeaderboardManager leaderboardManager;
    public PlayerIDManager playerIDManager;

    public ScoreController scoreController;

    public GameObject mainCamera;
    public GameObject player;
    
    public bool isGameOver;
    public bool isGameOnPause;

    private void Start()
    {
        if (mainCamera.GetComponent<CameraController>().isCameraMoved == 0)
        {
            StartPause();
        }
        else
        {
            uIManager.StartButton();
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        audioManager.MainThemePlay();
        mainCamera.GetComponent<CameraController>().CameraMove();
    }

    public void ResumeGame()
    {
        player.GetComponent<PlayerController>().SwitchRBSimulation();
        StartCoroutine(spawnManager.SpawnWalls());
        isGameOnPause = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1.0f;
        isGameOnPause = false;
        audioManager.MainThemeUnPause();
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        isGameOnPause = true;
        audioManager.MainThemePause();
    }

    public void StartPause()
    {
        Time.timeScale = 0.0f;
        audioManager.MainThemePause();
    }
}
