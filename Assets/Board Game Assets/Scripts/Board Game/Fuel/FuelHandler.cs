using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelHandler : MonoBehaviour, IBoardPlayerState
{
    public const float startingAmount = 50;
    public const float winningAmount = 200f;

    public PlayerFuel GetPlayersFuel(GameObject player)
    {
        return player.GetComponent<PlayerFuel>();
    }

    public GameObject SetPlayersFuel(GameObject player, float value)
    {
        PlayerFuel playerFuel = GetPlayersFuel(player);
        playerFuel.fuel = value;
        return player;
    }

    public GameObject AddFuelToPlayer(GameObject player, float amount, bool showTooltip)
    {
        AddFuel.AddFuelToPlayer(player, amount, showTooltip);
        return player;
    }

    public GameObject RemoveFuelFromPlayer(GameObject player, float amount, bool showTooltip)
    {
        RemoveFuel.RemoveFuelFromPlayer(player, amount, showTooltip);
        return player;
    }

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