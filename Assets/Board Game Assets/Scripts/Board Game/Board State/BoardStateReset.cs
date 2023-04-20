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
            stateComponent.fuel = startingFuel;
            stateComponent.hull = startingHull;
            stateComponent.pathIndex = 0;
            stateComponent.checkpointIndex = 0;
            stateComponent.turnsToSkip = 0;
            stateComponent.rank = 4;
        }
    }

    private float startingFuel => GameConfig.GetConfig<FuelConfig>().startingFuel;
    private float startingHull => HullHandler.startingHull;
    
}