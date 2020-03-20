using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardHullInit : MonoBehaviour, IBoardStateInitializer
{
    public void SavePlayerState(GameObject player, PlayerBoardState playerState)
    {
        float amount = playerState.hull = player.GetComponent<PlayerHull>().HullPercentage;
        print("Saving the players fuel: " + amount);
    }

    public void SetupPlayerState(GameObject player, PlayerBoardState playerState)
    {
        float amount = playerState.hull;
        player.GetComponent<PlayerHull>().HullPercentage = amount;
        print("Players initial hull set: " + amount);
    }
}
