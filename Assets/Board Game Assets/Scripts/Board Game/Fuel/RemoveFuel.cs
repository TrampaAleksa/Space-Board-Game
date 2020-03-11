using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFuel 
{
    public static GameObject RemoveFuelFromPlayer(GameObject player, float amount)
    {
        PlayerFuel playerFuel = InstanceManager.Instance.Get<FuelHandler>().GetPlayersFuel(player);
        playerFuel.fuel -= amount;
        InstanceManager.Instance.Get<TooltipHandler>().ShowPlayersTooltip(player, "-" + amount);
        if (playerFuel.fuel < 0)
        {
            playerFuel.fuel = 0;
            //TODO -- freeze the player and skip his next 2 turns
        }
        return player;
    }
}
