using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPlayerHealed : IBuildActivityTooltip
{
    private int value;
    private GameObject player;

    public ATPlayerHealed(GameObject player, int value)
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
        tooltipMessage += " repaired for ";
        tooltipMessage += RichTextBuilder.AddTagToString(value.ToString(), "color", color);
        tooltipMessage += " health";
        return tooltipMessage;
    }
}