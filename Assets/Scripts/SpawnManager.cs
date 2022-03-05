using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    public GameObject[] wallPrefab;

    private float spawnRate;

    private Vector2 spawnPos = new Vector2(20, 0);

    public IEnumerator SpawnWalls()
    {
        while (!gameManager.isGameOver)
        {
            spawnRate = Random.Range(1.0f, 3.0f);
            yield return new WaitForSeconds(spawnRate);
            Spawn();
        }
    }

    private void Spawn()
    {
        int wallInd = Random.Range(0, 14);
        Instantiate(wallPrefab[wallInd], spawnPos, wallPrefab[wallInd].transform.rotation);
    }
}
