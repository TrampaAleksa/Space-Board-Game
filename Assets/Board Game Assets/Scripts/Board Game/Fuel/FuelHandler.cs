using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelHandler : MonoBehaviour
{
    public const float StartingAmount = 50;
    public const float WinningAmount = 200f;

    private AddFuel _addFuel;

    private void Start()
    {
        _addFuel = new AddFuel();
    }

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
        var playerFuel = GetPlayersFuel(player);
        float fuelAfterAdding = playerFuel.fuel + amount;
        var players = InstanceManager.Instance.Get<PlayersHandler>().gameObjects;
        if (VictoryHandler.Instance.CheckGameWon(fuelAfterAdding))
            VictoryHandler.Instance.Win(players);
        else
            _addFuel.ShowPlayerGainedFuelTooltip(player, amount, showTooltip);
        StartCoroutine(_addFuel.AddFuelLerp(playerFuel, fuelAfterAdding));
        return player;
    }

    public GameObject RemoveFuelFromPlayer(GameObject player, float amount, bool showTooltip)
    {
        RemoveFuel.RemoveFuelFromPlayer(player, amount, showTooltip);
        return player;
    }

}