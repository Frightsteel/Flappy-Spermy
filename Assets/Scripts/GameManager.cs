using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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

    public TextMeshProUGUI infoText;

    //public bool isGameOver;
    //public bool isGameOnPause;
    //public bool isPlaying;

    public enum GameState
    {
        MainMenu,
        Starting,
        Waiting,
        Playing,
        GameOver,
        Pause
    }

    public GameState currentGameState;
    
    private void Start()
    {
        if (CameraController.isCameraMoved == 0)
        {
            //StartPause();
            SwitchGameState(GameState.MainMenu);
        }
        else
        {
            uIManager.StartButton();
            //SwitchGameState(GameState.Starting);
        }
    }

    private void Update()
    {
        switch (currentGameState)
        {
            case GameState.MainMenu:

                break;

            case GameState.Starting:

                if (CameraController.isCameraMoved == 1)
                {
                    SwitchGameState(GameState.Waiting);
                }

                break;

            case GameState.Waiting:

                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began /*Input.GetKeyDown(KeyCode.Space)*/)
                {
                    uIManager.SwitchInfoText();
                    player.GetComponent<PlayerController>().SwitchRBSimulation();
                    StartCoroutine(spawnManager.SpawnWalls());
                    SwitchGameState(GameState.Playing);
                }

                break;

            case GameState.Playing:

                break;

            case GameState.GameOver:

                break;

            case GameState.Pause:

                break;
        }
    }

    public void SwitchGameState(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.MainMenu:

                Time.timeScale = 0.0f;
                audioManager.MainThemePause();

                break;

            case GameState.Starting:

                Time.timeScale = 1.0f;
                audioManager.MainThemePlay();
                mainCamera.GetComponent<CameraController>().CameraMove();

                break;

            case GameState.Waiting:

                infoText.text = "TAP!";
                uIManager.SwitchInfoText();

                break;

            case GameState.Playing:

                Time.timeScale = 1.0f;
                uIManager.SwitchInGameUI();
                audioManager.MainThemeUnPause();

                break;

            case GameState.GameOver:

                audioManager.GameOverSoundPlay();
                uIManager.GameOverMenuOpen();

                break;

            case GameState.Pause:

                Time.timeScale = 0.0f;
                audioManager.MainThemePause();
                break;
        }
        currentGameState = newGameState;
        Debug.Log(currentGameState + " - Game State");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnApplicationQuit() // temporary
    {
        PlayerPrefs.DeleteKey("isCameraMoved");
    }
}
