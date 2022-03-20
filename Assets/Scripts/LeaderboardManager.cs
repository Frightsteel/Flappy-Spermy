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
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
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
                Debug.Log("Failed");
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
                Debug.Log("Failed");
            }
        });
    }

    public void SubmitScore()
    {
        memberID = PlayerPrefs.GetInt("PlayerID");
        playerBestScore = PlayerPrefs.GetInt("bestScore");

        LootLockerSDKManager.SubmitScore(memberID.ToString(), playerBestScore, gameID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }
}
