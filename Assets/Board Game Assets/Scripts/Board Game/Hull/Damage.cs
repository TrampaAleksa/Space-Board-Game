using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public static GameObject DamagePlayer(GameObject player, float value)
    {
        player.GetComponent<PlayerHull>().HullPercentage -= value;
        InstanceManager.Instance.Get<TooltipHandler>().ShowPlayersTooltip(player, "-"+value);
        //damage sound?
        if (player.GetComponent<PlayerHull>().HullPercentage <= 0)
        {
            player.GetComponent<PlayerCheckpoint>().RespawnAtCheckpoint();
            //respawn sound?
        }
        return player;
    }
}