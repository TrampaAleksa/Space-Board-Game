using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPlayerDamaged : IBuildActivityTooltip
{
    private int value;
    private GameObject player;

    public ATPlayerDamaged(GameObject player, int value)
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
        tooltipMessage += " took ";
        tooltipMessage += RichTextBuilder.AddTagToString(value.ToString(), "color", color);
        tooltipMessage += " damage";
        return tooltipMessage;
    }
}