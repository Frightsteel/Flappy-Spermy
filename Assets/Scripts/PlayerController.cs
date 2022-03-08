using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    
    private Rigidbody2D playerRB;

    private Animator playerAnim;
    private AudioSource playerAS;

    public AudioClip jumpSound;

    private float yForce = 8f;
    private float yBorder = 6.0f;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerAS = GetComponent<AudioSource>();
    }

    void Update()
    {
        CheckJump();
        CheckBorder();
    }

    public void CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameManager.isGameOver && !gameManager.isGameOnPause)
        {
            playerRB.velocity = new Vector2(0, yForce);
            playerAS.PlayOneShot(jumpSound, 0.5f);
        }
    }

    private void CheckBorder()
    {
        if (transform.position.y > yBorder)
        {
            transform.position = new Vector2(transform.position.x, yBorder);
        }

        if (transform.position.y < -yBorder)
        {
            transform.position = new Vector2(transform.position.x, -yBorder);
        }
    }

    public void RBSimulation()
    {
        playerRB.simulated = !playerRB.simulated;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block") && !gameManager.isGameOver)
        {
            gameManager.isGameOver = true;
            gameManager.isGameOnPause = true;

            playerAnim.SetBool("death", true);
            gameManager.audioManager.GameOverSoundPlay();

            gameManager.uIManager.GameOverMenuOpen(gameManager.score);
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Entry") && !gameManager.isGameOver)
        {
            gameManager.ScoreUpdate();
        }
    }
}
