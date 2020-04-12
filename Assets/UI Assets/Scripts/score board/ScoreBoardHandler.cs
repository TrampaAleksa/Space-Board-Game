using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreBoardHandler : MonoBehaviour
{
    public PlayerBoardState[] playerBoardStates;
    // Start is called before the first frame update
    void Start()
    {
        playerBoardStates = BoardStateHolder.Instance.playerBoardStates;
        playerBoardStates[0].rank = 2;
        playerBoardStates[1].rank = 1;
        playerBoardStates[2].rank = 4;
        playerBoardStates[3].rank = 3;
        playerBoardStates[0].name = "prvi";
        playerBoardStates[1].name = "drugi";
        playerBoardStates[2].name = "treci";
        playerBoardStates[3].name = "cetvrti";
        FillScoreBoard();
    }

    public void FillScoreBoard()
    {
        var states = from playerBoardState in playerBoardStates
            orderby playerBoardState.rank
            select playerBoardState;

        foreach (var playerBoardState in states)
        {
            Debug.Log(playerBoardState.name);
        }
    }
}
