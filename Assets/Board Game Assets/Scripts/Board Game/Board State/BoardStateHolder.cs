using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardStateHolder : MonoBehaviour
{
    public PlayerBoardState[] playerBoardStates;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        playerBoardStates = InitializePlayerBoardStates();
    }

    private PlayerBoardState[] InitializePlayerBoardStates()
    {
        //TODO -- extract a JSON file of the initial player board states
        playerBoardStates = new PlayerBoardState[4];
        for (int i = 0; i < playerBoardStates.Length; i++)
        {
            playerBoardStates[i] = ScriptableObject.CreateInstance<PlayerBoardState>();
            playerBoardStates[i].fuel = FuelHandler.StartingAmount;
            playerBoardStates[i].hull = HullHandler.STARTING_HULL;
            playerBoardStates[i].rank = RankHandler.StartingRank;
            playerBoardStates[i].pathIndex = FieldHandler.StartingIndex;
            playerBoardStates[i].checkpointIndex = FieldHandler.StartingIndex;
            playerBoardStates[i].turnsToSkip = 0;
            playerBoardStates[i].playerName = "Default name";
        }
        return playerBoardStates;
    }
}