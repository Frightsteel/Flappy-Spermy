using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIDManager : MonoBehaviour
{
    private int playerID = 0;
    
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerID"))
        {
            //Debug.Log("anime");
        }
        playerID = PlayerPrefs.GetInt("PlayerID");
        //Debug.Log(playerID + " - playerID");
        if (playerID == 0)
        {
            playerID = Random.Range(100000, 1000000);
            PlayerPrefs.SetInt("PlayerID", playerID);
            //Debug.Log(playerID + " - playerID");
        }
    }
}
