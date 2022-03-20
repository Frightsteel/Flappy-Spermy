using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIDManager : MonoBehaviour
{
    private int playerID = 0;
    
    void Start()
    {
        playerID = PlayerPrefs.GetInt("PlayerID");
        if (playerID == 0)
        {
            playerID = Random.Range(100000, 1000000);
            PlayerPrefs.SetInt("PlayerID", playerID);
        }
    }
}
