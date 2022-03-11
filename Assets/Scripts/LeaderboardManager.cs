using LootLocker.Requests;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    public int gameID;

    public int playerScore; //best score
    public int memberID; //account ID

    public int maxScores = 5;
    public TextMeshProUGUI[] playerNames;
    public TextMeshProUGUI[] playerScores;

    public TextMeshProUGUI playerRankText;
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

    public void ShowScores()
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
                        playerNames[i].text = "You";
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
                playerRankText.text = response.rank.ToString();
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
        playerScore = PlayerPrefs.GetInt("bestScore");

        LootLockerSDKManager.SubmitScore(memberID.ToString(), playerScore, gameID, (response) =>
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
