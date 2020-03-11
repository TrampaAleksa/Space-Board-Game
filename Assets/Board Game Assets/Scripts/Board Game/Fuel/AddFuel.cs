using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFuel 
{
     public static GameObject AddFuelToPlayer(GameObject player, float amount)
    {
        PlayerFuel playerFuel = InstanceManager.Instance.Get<FuelHandler>().GetPlayersFuel(player);
        playerFuel.fuel += amount;
        InstanceManager.Instance.Get<TooltipHandler>().ShowPlayersTooltip(player, "+" + amount);
        if (playerFuel.fuel >= FuelHandler.winningAmount)
        {
            Debug.Log("PLAYER: " + player.name + " WON THE GAME!");
        }
        return player;
    }
}
