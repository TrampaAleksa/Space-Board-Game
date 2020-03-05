using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardStateReset : MonoBehaviour
{
    public PlayerBoardState[] playerBoardStates;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnApplicationQuit()
    {
        ResetToDefaultState();
    }

    public void ResetToDefaultState()
    {
        foreach (var stateComponent in playerBoardStates)
        {
            stateComponent.fuel = FuelHandler.startingAmount;
            stateComponent.hull = HullHandler.STARTING_HULL;
            stateComponent.pathIndex = 0;
            stateComponent.checkpointIndex = 0;
            stateComponent.turnsToSkip = 0;
        }
    }
}
