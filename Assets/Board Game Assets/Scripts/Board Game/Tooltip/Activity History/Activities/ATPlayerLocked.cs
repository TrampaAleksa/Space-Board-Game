using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPlayerLocked : IBuildActivityTooltip
{
    private int numberOfTurns;
    private GameObject player;

    public ATPlayerLocked(GameObject player, int value)
    {
        this.player = player;
        this.numberOfTurns = value;
    }

    public string BuildActivityTooltip()
    {
        string playerName = player.GetComponent<PlayerName>().playerName.text;
        string color = player.GetComponent<Player>().color;
        string tooltipMessage = "";

        tooltipMessage += RichTextBuilder.AddTagToString(playerName, "color", color);
        tooltipMessage += " engines broken for ";
        tooltipMessage += RichTextBuilder.AddTagToString(numberOfTurns.ToString(), "color", color);
        tooltipMessage += " turn(s)";
        return tooltipMessage;
    }
}