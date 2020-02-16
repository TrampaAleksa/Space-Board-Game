using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public static GameObject DamagePlayer(GameObject player, float value)
    {
        player.GetComponent<PlayerHull>().HullPercentage -= value;
        if (player.GetComponent<PlayerHull>().HullPercentage <= 0)
        {
            player.GetComponent<PlayerCheckpoint>().RespawnAtCheckpoint();
        }
        return player;
    }
}
