using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATSwappedPlaces : ActivityTooltipBuilder
{
    public ATSwappedPlaces(GameObject player1, GameObject player2) : base(player1, player2)
    {
        BuildActivityTooltip();
    }

    public sealed override void BuildActivityTooltip()
    {
        tooltipMessage += player1Name;
        tooltipMessage += " swapped places with ";
        tooltipMessage += player2Name;
    }
}