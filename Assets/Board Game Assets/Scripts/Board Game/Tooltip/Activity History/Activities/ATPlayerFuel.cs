using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPlayerFuel : IBuildActivityTooltip
{
    private int value;
    private GameObject player;

    public ATPlayerFuel(GameObject player, int value)
    {
        this.player = player;
        this.value = value;
    }

    public string BuildActivityTooltip()
    {
        string playerName = player.GetComponent<PlayerName>().playerName.text;
        string color = player.GetComponent<Player>().color;
        string tooltipMessage = "";

        tooltipMessage += RichTextBuilder.AddTagToString(playerName, "color", color);
        tooltipMessage += " visited fuel station. Gained ";
        tooltipMessage += RichTextBuilder.AddTagToString(value.ToString(), "color", color);
        tooltipMessage += " fuel";
        return tooltipMessage;
    }
}