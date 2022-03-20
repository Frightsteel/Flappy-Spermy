using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameManager gameManager;
    
    [SerializeField]
    private LeanTweenType easeType;

    public int isCameraMoved = 0;

    private void Awake()
    {
        isCameraMoved = PlayerPrefs.GetInt("isCameraMoved");
    }

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void CameraMove()
    {   
        if (isCameraMoved == 0)
        {
            LeanTween.moveX(gameObject, 0.0f, 4.0f).setEase(easeType).setIgnoreTimeScale(true).setOnComplete(OnComplete);
        }
        else
        {
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
            gameManager.ResumeGame();
        }

    }

    private void OnComplete()
    {
        gameManager.ResumeGame();
        PlayerPrefs.SetInt("isCameraMoved", 1);
    }
}
