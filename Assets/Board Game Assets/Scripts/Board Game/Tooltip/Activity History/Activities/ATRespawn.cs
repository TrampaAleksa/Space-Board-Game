using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATRespawn : IBuildActivityTooltip
{
    private GameObject player;

    public ATRespawn(GameObject player)
    {
        this.player = player;
    }

    public string BuildActivityTooltip()
    {
        string playerName = player.GetComponent<PlayerName>().playerName.text;
        string color = player.GetComponent<Player>().color;
        int fuelAmount = (int)player.GetComponent<PlayerFuel>().fuel;
        string tooltipMessage = "";

        tooltipMessage += RichTextBuilder.AddTagToString(playerName, "color", color);
        tooltipMessage += " Destroyed. Respawned with  ";
        tooltipMessage += RichTextBuilder.AddTagToString(fuelAmount.ToString(), "color", color);
         tooltipMessage += " fuel  ";
        return tooltipMessage;
    }
}
