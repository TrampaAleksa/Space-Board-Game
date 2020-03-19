using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATMoveInDirection : ActivityTooltipBuilder
{
    private string direction;

    public ATMoveInDirection(GameObject player, int value, string direction) : base(player, value)
    {
        this.direction = direction;
        BuildActivityTooltip();
    }

    public sealed override void BuildActivityTooltip()
    {
        tooltipMessage += player1Name;
        tooltipMessage += " Moved  ";
        tooltipMessage += value;
        tooltipMessage += " fields ";
        tooltipMessage += direction;
    }
}