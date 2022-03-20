using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    public GameManager gameManager;

    private void OnApplicationFocus(bool focus)
    {
        gameManager.isGameOnPause = !focus;

        UpdateCameraSave();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        gameManager.isGameOnPause = pauseStatus;

        UpdateCameraSave();
    }

    private void UpdateCameraSave()
    {
        if (gameManager.isGameOnPause)
        {
            PlayerPrefs.DeleteKey("isCameraMoved");
        }
        else
        {
            PlayerPrefs.SetInt("isCameraMoved", 1);
        }
    }
}
