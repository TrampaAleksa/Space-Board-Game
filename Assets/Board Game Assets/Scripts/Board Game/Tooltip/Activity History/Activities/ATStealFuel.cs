using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATStealFuel : IBuildActivityTooltip
{
    private GameObject player1;
    private GameObject player2;
    private int value;

    public ATStealFuel(GameObject player1, GameObject player2, int value)
    {
        this.player1 = player1;
        this.player2 = player2;
        this.value = value;
    }

    public string BuildActivityTooltip()
    {
        string playerName1 = player1.GetComponent<PlayerName>().playerName.text;
        string color1 = player1.GetComponent<Player>().color;
        string playerName2 = player2.GetComponent<PlayerName>().playerName.text;
        string color2 = player2.GetComponent<Player>().color;

        string tooltipMessage = "";

        tooltipMessage += RichTextBuilder.AddTagToString(playerName1, "color", color1);
        tooltipMessage += " stole " + value;
        tooltipMessage += " fuel from ";
        tooltipMessage += RichTextBuilder.AddTagToString(playerName2, "color", color2);
        return tooltipMessage;
    }
}
