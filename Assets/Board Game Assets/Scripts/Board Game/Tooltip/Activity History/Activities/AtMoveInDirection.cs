using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATMoveInDirection : IBuildActivityTooltip
{
    private int value;
    private GameObject player;
    private string direction;

    public ATMoveInDirection(GameObject player, int value, string direction)
    {
        this.player = player;
        this.value = value;
        this.direction = direction;
    }

    public string BuildActivityTooltip()
    {
        string playerName = player.GetComponent<PlayerName>().playerName.text;
        string color = player.GetComponent<Player>().color;
        string tooltipMessage = "";

        tooltipMessage += RichTextBuilder.AddTagToString(playerName, "color", color);
        tooltipMessage += " Moved  ";
        tooltipMessage += RichTextBuilder.AddTagToString(value.ToString(), "color", color);
        tooltipMessage += " fields ";
        tooltipMessage += direction;

        return tooltipMessage;
    }
}
