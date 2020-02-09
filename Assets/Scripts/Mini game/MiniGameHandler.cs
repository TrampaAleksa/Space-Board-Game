using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameHandler : MonoBehaviour
{
    private BoardStateHolder boardStateHolder;
    private PlayersHandler playersHandler;
    private FuelHandler fuelHandler;
    private HealthHandler healthHandler;
    private PlayerFieldMovement movementHandler;
    void Start()
    {
        boardStateHolder = GameObject.Find("BoardState").GetComponent<BoardStateHolder>();
        playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
        fuelHandler = InstanceManager.Instance.Get<FuelHandler>();
        healthHandler = InstanceManager.Instance.Get<HealthHandler>();
        movementHandler = InstanceManager.Instance.Get<PlayerFieldMovement>();
        if(boardStateHolder.playerBoardStates != null)
        SetupBoardOnLoad();
    }

    public void SetupBoardOnLoad()
    {

        print("setup the board");
        PlayerBoardState[] playerBoardStates = boardStateHolder.playerBoardStates;
        for (int i = 0; i < playerBoardStates.Length; i++)
        {
            PlayerBoardState currentPlayerBoardState = boardStateHolder.playerBoardStates[i];
            GameObject currentPlayer = playersHandler.GetPlayer(i);
            // set players fields, fuels and health
            movementHandler.SetCurrentField(currentPlayerBoardState.pathIndex,playersHandler.GetPlayer(i));
            fuelHandler.SetPlayersFuel(currentPlayer, currentPlayerBoardState.fuel);
            healthHandler.SetPlayersHealth(currentPlayer, currentPlayerBoardState.health);
        }
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
