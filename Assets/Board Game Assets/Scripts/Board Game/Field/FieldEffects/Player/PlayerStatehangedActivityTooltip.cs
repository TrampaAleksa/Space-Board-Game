using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatehangedActivityTooltip : IBuildActivityTooltip
{
    private string playerName;
    private int value;
    private string valueName;
    private string message;
    private string color;

    public PlayerStatehangedActivityTooltip(string playerName, int value, string valueName, string message, string color)
    {
        this.playerName = playerName;
        this.value = value;
        this.valueName = valueName;
        this.message = message;
        this.color = color;
    }

    public string BuildActivityTooltip()
    {
        string tooltipMessage = "";

        tooltipMessage += RichTextBuilder.AddTagToString(playerName, "color", color);
        tooltipMessage += " " + message;
        tooltipMessage += " " + RichTextBuilder.AddTagToString(value.ToString(), "color", color);
        tooltipMessage += " " + valueName;
        return tooltipMessage;
    }
}