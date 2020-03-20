using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardFuelInit : MonoBehaviour, IBoardStateInitializer
{
    public void SavePlayerState(GameObject player, PlayerBoardState playerState)
    {
        float amount = playerState.fuel = player.GetComponent<PlayerFuel>().fuel;
        print("Saving the players fuel: " + amount);
    }

    public void SetupPlayerState(GameObject player, PlayerBoardState playerState)
    {
        float amount = playerState.fuel;
        player.GetComponent<PlayerFuel>().fuel = amount;
        print("Players initial fuel set: " + amount);
    }
}