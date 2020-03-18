using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATTeleported : IBuildActivityTooltip
{
    private GameObject _player;

    public ATTeleported(GameObject player)
    {
        this._player = player;
    }

    public string BuildActivityTooltip()
    {
        string playerName = _player.GetComponent<PlayerName>().playerName.text;
        string color = _player.GetComponent<Player>().color;

        string tooltipMessage = "";

        tooltipMessage += RichTextBuilder.AddTagToString(playerName, "color", color);
        tooltipMessage += " teleported to another field ";
        return tooltipMessage;
    }
}
