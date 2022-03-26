using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    public GameManager gameManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        //if (!focus)
        //{
        //    gameManager.SwitchGameState(GameManager.GameState.Pause);
        //}
        //else
        //{
        //    gameManager.SwitchGameState(GameManager.GameState.Playing);
        //}

        UpdateCameraSave(!focus);
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        //if (pauseStatus)
        //{
        //    gameManager.SwitchGameState(GameManager.GameState.Pause);
        //}
        //else
        //{
        //    gameManager.SwitchGameState(GameManager.GameState.Playing);
        //}

        UpdateCameraSave(pauseStatus);
    }

    private void UpdateCameraSave(bool isGameOnPaused)
    {
        if (isGameOnPaused)
        {
            PlayerPrefs.DeleteKey("isCameraMoved");
            Debug.Log(1);
        }
        else
        {
            PlayerPrefs.SetInt("isCameraMoved", 1);
            Debug.Log(2);
        }
    }
}
