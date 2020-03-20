using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameHandler : MonoBehaviour, IBoardStateInitializer
{
    public void SavePlayerState(GameObject player, PlayerBoardState playerState)
    {
    }

    public void SetupPlayerState(GameObject player, PlayerBoardState playerState)
    {
        player.GetComponent<PlayerName>().playerName.text = playerState.playerName;
    }
   
}
