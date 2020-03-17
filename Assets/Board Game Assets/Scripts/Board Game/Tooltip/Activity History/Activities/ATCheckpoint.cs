using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATCheckpoint : IBuildActivityTooltip
{
    private GameObject player;

    public ATCheckpoint(GameObject player)
    {
        this.player = player;
    }

    public string BuildActivityTooltip()
    {
        string playerName = player.GetComponent<PlayerName>().playerName.text;
        string color = player.GetComponent<Player>().color;
        string tooltipMessage = "";

        tooltipMessage += RichTextBuilder.AddTagToString(playerName, "color", color);
        tooltipMessage += " got a checkpoint  ";
        return tooltipMessage;
    }
}
