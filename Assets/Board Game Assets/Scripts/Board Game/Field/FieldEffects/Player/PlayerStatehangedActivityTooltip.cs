using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatehangedActivityTooltip : IBuildActivityTooltip
{
    private string playerName;
    private int value;
    private string valueName;
    private string message;

    public PlayerStatehangedActivityTooltip(string playerName, int value, string valueName, string message)
    {
        this.playerName = playerName;
        this.value = value;
        this.valueName = valueName;
        this.message = message;
    }

    public string BuildActivityTooltip()
    {
        string tooltipMessage = "";

        tooltipMessage += RichTextBuilder.AddTagToString(playerName, "color", "red");
        tooltipMessage += " " + message;
        tooltipMessage += " " + RichTextBuilder.AddTagToString(value.ToString(), "color", "red");
        tooltipMessage += " " + valueName;
        return tooltipMessage;
    }
}