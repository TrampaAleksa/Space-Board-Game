using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameHandler : MonoBehaviour
{
    private BoardStateHolder boardStateHolder;
    public PlayersHandler playersHandler;
    public FuelHandler fuelHandler;
    public HealthHandler healthHandler;
    public PlayerFieldMovement movementHandler;
    void Start()
    {
      
        //SetupBoardOnLoad();
    }

    public bool SetupBoardOnLoad()
    {
        boardStateHolder = GameObject.Find("BoardState").GetComponent<BoardStateHolder>();
        playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
        fuelHandler = InstanceManager.Instance.Get<FuelHandler>();
        healthHandler = InstanceManager.Instance.Get<HealthHandler>();
        movementHandler = InstanceManager.Instance.Get<PlayerFieldMovement>();

        if (boardStateHolder.playerBoardStates != null)
        {
            print("setup the board");
            PlayerBoardState[] playerBoardStates = boardStateHolder.playerBoardStates;
            for (int i = 0; i < playerBoardStates.Length; i++)
            {
                PlayerBoardState currentPlayerBoardState = boardStateHolder.playerBoardStates[i];
                GameObject currentPlayer = playersHandler.GetPlayer(i);
                // set players fields, fuels and health
                movementHandler.SetCurrentField(currentPlayerBoardState.pathIndex, playersHandler.GetPlayer(i));
                fuelHandler.SetPlayersFuel(currentPlayer, currentPlayerBoardState.fuel);
                healthHandler.SetPlayersHealth(currentPlayer, currentPlayerBoardState.health);
            }
            return true;
        }
        return false;
    }

    public void SnapshotBoardState()
    {
        PlayerBoardState[] playerBoardStates = boardStateHolder.playerBoardStates;
        for (int i=0; i< playerBoardStates.Length; i++)
        {
            PlayerBoardState currentPlayerBoardState = boardStateHolder.playerBoardStates[i];
            GameObject currentPlayer = playersHandler.GetPlayer(i);
            currentPlayerBoardState.pathIndex = movementHandler.GetCurrentFieldIndex(currentPlayer);
            currentPlayerBoardState.health = healthHandler.GetPlayerHealth(currentPlayer).health;
            currentPlayerBoardState.fuel = fuelHandler.GetPlayersFuel(currentPlayer).fuel;
        }
    }

}
