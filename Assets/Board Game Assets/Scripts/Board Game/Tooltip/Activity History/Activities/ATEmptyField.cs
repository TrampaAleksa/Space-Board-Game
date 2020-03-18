using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATEmptyField : IBuildActivityTooltip
{
    private GameObject _player;

    public ATEmptyField(GameObject player)
    {
        this._player = player;
    }

    public string BuildActivityTooltip()
    {
        string playerName = _player.GetComponent<PlayerName>().playerName.text;
        string color = _player.GetComponent<Player>().color;

        string tooltipMessage = "";

        tooltipMessage += RichTextBuilder.AddTagToString(playerName, "color", color);
        tooltipMessage += " landed on an empty field ";
        return tooltipMessage;
    }
}

