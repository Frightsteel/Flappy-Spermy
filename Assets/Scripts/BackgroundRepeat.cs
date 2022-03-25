using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private float speed; // 3.0f for back and 5.0f for front

    private Vector2 startPos;
    private float repeatWidth = 51.2f;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        startPos = transform.position;
    }

    void Update()
    {
        if (gameManager.currentGameState != GameManager.GameState.Pause && gameManager.currentGameState != GameManager.GameState.GameOver)
        {
            Move();
            CheckRepeat();
        }
    }

    private void Move()
    {
        transform.Translate(speed * Time.unscaledDeltaTime * Vector2.left);
    }

    private void CheckRepeat()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
