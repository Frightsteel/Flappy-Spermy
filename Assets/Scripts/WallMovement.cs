using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    private GameManager gameManager;
    
    private float speed = 5.0f;
    private float xBound = 20;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        Move();
        CheckBound();
    }

    private void Move()
    {
        if (!gameManager.isGameOver)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    private void CheckBound()
    {
        if (transform.position.x < -xBound)
        {
            Destroy(gameObject);
        }
    }
}
