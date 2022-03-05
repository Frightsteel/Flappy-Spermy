using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    internal UIManager uIManager;
    [SerializeField]
    private SpawnManager spawnManager;
    [SerializeField]
    internal AudioManager audioManager;

    public GameObject mainCamera;
    public GameObject player;

    public int score = 0;
    public bool isGameOver = false;
    public bool isGameActive = false;

    private void Awake()
    {
        PauseGame();
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

        mainCamera.GetComponent<CameraAnimation>().CameraMove();
    }

    public void ResumeGame()
    {
        player.GetComponent<PlayerController>().RBSimulation();

        StartCoroutine(spawnManager.SpawnWalls());
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
}
