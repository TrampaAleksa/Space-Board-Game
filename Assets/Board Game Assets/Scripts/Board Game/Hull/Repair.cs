using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair
{
    public static GameObject RepairPlayer(GameObject player, float value, float maximumAmount)
    {
        PlayerHull playerHull = player.GetComponent<PlayerHull>();
        playerHull.HullPercentage += value;
        InstanceManager.Instance.Get<TooltipHandler>().ShowPlayersTooltip(player, "+" + value + " health");
        //repair sound?
        if (playerHull.HullPercentage >= maximumAmount)
        {
            playerHull.HullPercentage = maximumAmount;
        }

        return player;
    }
}