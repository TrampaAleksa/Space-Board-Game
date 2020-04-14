using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameScoreBoardHandler : MonoBehaviour
{
    public Text[] fuelAmounts;
    public Text[] names;
    void Start()
    { 
        var playerBoardStates = BoardStateHolder.Instance.playerBoardStates;
        FillScoreBoard(playerBoardStates);
    }

    private MiniGameScoreBoardHandler FillWithTestData(PlayerBoardState[] playerBoardStates)
    {
        playerBoardStates[0].rank = 2;
        playerBoardStates[1].rank = 1;
        playerBoardStates[2].rank = 4;
        playerBoardStates[3].rank = 3;
        playerBoardStates[0].playerName = "prvi";
        playerBoardStates[1].playerName = "drugi";
        playerBoardStates[2].playerName = "treci";
        playerBoardStates[3].playerName = "cetvrti";
        return this;
    }

    private void FillScoreBoard(PlayerBoardState[] playerBoardStates)
    {
        var states = from playerBoardState in playerBoardStates
            orderby playerBoardState.rank
            select playerBoardState;

        var i = 0;
        foreach (var playerBoardState in states)
        {
            fuelAmounts[i].text = RankHandler.PrizeForRank(playerBoardState.rank).ToString();
            names[i].text = playerBoardState.playerName;
            Debug.Log(playerBoardState.name);
            i++;
        }
    }

    public void ContinueToBoardGame()
    {
        const int boardGameSceneIndex = 1;
        SceneManager.LoadScene(boardGameSceneIndex);
    }
}
