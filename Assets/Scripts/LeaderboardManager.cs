using LootLocker.Requests;
using TMPro;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public int gameID;

    [SerializeField]
    private int memberID; //account ID
    public int playerBestScore; //best score

    public int maxScores = 5; //count of scores to show
    public TextMeshProUGUI[] playerNames;
    public TextMeshProUGUI[] playerScores;

    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI playerScoreText;

    void Start()
    {
        LootLockerSDKManager.StartSession("Player", (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success 0");
            }
            else
            {
                Debug.Log("Failed 0");
            }
        });
    }

    public void UpdateScores()
    {
        LootLockerSDKManager.GetScoreList(gameID, maxScores, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;

                for (int i = 0; i < scores.Length; i++)
                {
                    if (memberID.ToString() == scores[i].member_id)
                    {
                        playerNames[i].text = (i + 1) + ".You";
                        playerScores[i].color = playerNames[i].color = new Color32(248,90,90,255);
                    }
                    playerScores[i].text = scores[i].score.ToString();
                }
            }
            else
            {
                Debug.Log("Failed 2");
            }
        });

        LootLockerSDKManager.GetMemberRank(gameID.ToString(), memberID, (response) =>
        {
            if (response.success)
            {
                playerNameText.text = response.rank + ".You";
                playerScoreText.text = response.score.ToString();
            }
            else
            {
               Debug.Log("Failed 3");
            }
        });
    }

    public void SubmitScore()
    {
        memberID = PlayerPrefs.GetInt("PlayerID");
        playerBestScore = PlayerPrefs.GetInt("BestScore");
        //Debug.Log(playerBestScore + " - submit score");
        //Debug.Log(memberID + " - member ID");

        LootLockerSDKManager.SubmitScore(memberID.ToString(), playerBestScore, gameID, (response) =>
        {
            if (response.success)
            {
                UpdateScores();
            }
            else
            {
                Debug.Log("Failed 1");
            }
        });
    }
}
