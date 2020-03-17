using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATSwappedPlaces : IBuildActivityTooltip
{
    private GameObject player1;
    private GameObject player2;

    public ATSwappedPlaces(GameObject player1, GameObject player2)
    {
        this.player1 = player1;
        this.player2 = player2;
    }

    public string BuildActivityTooltip()
    {
        string playerName1 = player1.GetComponent<PlayerName>().playerName.text;
        string color1 = player1.GetComponent<Player>().color;
        string playerName2 = player2.GetComponent<PlayerName>().playerName.text;
        string color2 = player2.GetComponent<Player>().color;

        string tooltipMessage = "";

        tooltipMessage += RichTextBuilder.AddTagToString(playerName1, "color", color1);
        tooltipMessage += " swapped places with ";
        tooltipMessage += RichTextBuilder.AddTagToString(playerName2, "color", color2);
        return tooltipMessage;
    }
}