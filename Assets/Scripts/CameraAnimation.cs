using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    private GameManager gameManager;
    
    public LeanTweenType easeType;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void CameraMove()
    {
        LeanTween.moveX(gameObject, 0.0f, 4.0f).setEase(easeType).setIgnoreTimeScale(true).setOnComplete(OnComplete);
    }

    private void OnComplete()
    {
        gameManager.ResumeGame();
    }
}
