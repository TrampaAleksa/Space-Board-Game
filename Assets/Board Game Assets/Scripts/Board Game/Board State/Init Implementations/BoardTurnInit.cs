using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTurnInit : MonoBehaviour, IBoardStateInitializer
{
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
