using System;
using UnityEngine;

public class TurnHandler : MonoBehaviour
{
    private EndTurn _endTurn;
    private void Start()
    {
        _endTurn = gameObject.AddComponent<EndTurn>();
    }

    public void EndCurrentPlayersTurn()
    {
        PlayersHandler playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
        playersHandler.SetToNextPlayer();
        bool brokenEngines = playersHandler.GetCurrentPlayer().GetComponent<PlayerMovement>().EnginesBroken();
        if (brokenEngines)
        {
            BrokenEngines.BrokenEngineAction();
            return;
        }
        // player ended turn sound
        _endTurn.StartNextPlayersTurn();
    }

    public GameObject AddPlayerTurnsToSkip(GameObject player, int turnsToSkip)
    {
        player.GetComponent<PlayerMovement>().turnsToSkip += turnsToSkip;
        return player;
    }

    public void SavePlayerState(GameObject player, PlayerBoardState playerState)
    {
        int turnsToSkip = playerState.turnsToSkip = player.GetComponent<PlayerMovement>().turnsToSkip;
        print("Saving the players turns to skip : " + turnsToSkip);
    }

    public void SetupPlayerState(GameObject player, PlayerBoardState playerState)
    {
        int turnsToSkip = playerState.turnsToSkip;
        player.GetComponent<PlayerMovement>().turnsToSkip = turnsToSkip;
    }
}