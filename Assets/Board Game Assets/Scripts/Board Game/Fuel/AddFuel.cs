using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFuel
{
    public static GameObject AddFuelToPlayer(GameObject player, float amount, bool showTooltip)
    {
        PlayerFuel playerFuel = InstanceManager.Instance.Get<FuelHandler>().GetPlayersFuel(player);
        playerFuel.fuel += amount;
        if (showTooltip)
            InstanceManager.Instance.Get<TooltipHandler>().ShowPlayersTooltip(player, "+" + amount + " fuel");
        if (playerFuel.fuel >= FuelHandler.winningAmount)
        {
            Debug.Log("PLAYER: " + player.name + " WON THE GAME!");
            InstanceManager.Instance.Get<TooltipHandler>().ShowPlayersTooltip(player, "WON THE GAME");
        }
        return player;
    }
}