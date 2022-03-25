using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        Flap();
        CheckBorder();
    }

    public void Flap()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) /*Input.GetKeyDown(KeyCode.Space)*/ && gameManager.currentGameState == GameManager.GameState.Playing)
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

    public void SwitchRBSimulation()
    {
        playerRB.simulated = !playerRB.simulated;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block") && gameManager.currentGameState == GameManager.GameState.Playing)
        {
            //gameManager.isGameOver = true;
            playerAnim.SetBool("death", true);
            gameManager.SwitchGameState(GameManager.GameState.GameOver);
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Entry") && gameManager.currentGameState == GameManager.GameState.Playing)
        {
            gameManager.scoreController.UpdateScore();
        }
    }
}
