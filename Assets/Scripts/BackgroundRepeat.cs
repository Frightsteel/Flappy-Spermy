using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    private GameManager gameManager;
    
    private Vector2 startPos;
    private float repeatWidth = 51.2f;
    public float speed = 3.0f;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        startPos = transform.position;
    }

    void Update()
    {
        Move();
        CheckRepeat();
    }

    private void Move()
    {
        if (!gameManager.isGameOver)
        {
            transform.Translate(Vector2.left * speed * Time.unscaledDeltaTime);
            //transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    private void CheckRepeat()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
