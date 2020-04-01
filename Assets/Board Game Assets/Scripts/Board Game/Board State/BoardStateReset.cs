using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardStateReset : MonoBehaviour
{
    public PlayerBoardState[] playerBoardStates;
    public static BoardStateReset Instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        ResetToDefaultState();
    }

    public void ResetToDefaultState()
    {
        foreach (var stateComponent in playerBoardStates)
        {
            stateComponent.fuel = FuelHandler.StartingAmount;
            stateComponent.hull = HullHandler.STARTING_HULL;
            stateComponent.pathIndex = 0;
            stateComponent.checkpointIndex = 0;
            stateComponent.turnsToSkip = 0;
            stateComponent.rank = 4;
        }
    }
}