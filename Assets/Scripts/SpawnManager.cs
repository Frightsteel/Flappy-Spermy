using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    public GameObject[] wallPrefab;

    private float spawnRate;

    private Vector2 spawnPos = new Vector2(7, 0);

    public IEnumerator SpawnWalls()
    {
        while (gameManager.currentGameState != GameManager.GameState.GameOver)
        {
            spawnRate = Random.Range(1.5f, 2.5f);
            yield return new WaitForSeconds(spawnRate);
            Spawn();
        }
    }

    private void Spawn()
    {
        int wallInd = Random.Range(0, 13);
        Instantiate(wallPrefab[wallInd], spawnPos, wallPrefab[wallInd].transform.rotation);
    }
}
