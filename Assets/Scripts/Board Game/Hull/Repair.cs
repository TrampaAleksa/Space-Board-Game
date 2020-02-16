using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair 
{
    public static GameObject RepairPlayer(GameObject player, float value, float maximumAmount)
    {
        PlayerHull playerHull = player.GetComponent<PlayerHull>();
        playerHull.HullPercentage += value;
        if (playerHull.HullPercentage >= maximumAmount)
        {
            playerHull.HullPercentage = maximumAmount;
        }

        return player;
    }
}
