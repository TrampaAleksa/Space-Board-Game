using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATStealFuel : ActivityTooltipBuilder
{
    public ATStealFuel(GameObject player1, GameObject player2, int value) : base(player1, player2, value)
    {
        BuildActivityTooltip();
    }

    public sealed override void BuildActivityTooltip()
    {
        tooltipMessage += player1Name;
        tooltipMessage += " stole " + value;
        tooltipMessage += " fuel from ";
        tooltipMessage += player2Name;
    }
}