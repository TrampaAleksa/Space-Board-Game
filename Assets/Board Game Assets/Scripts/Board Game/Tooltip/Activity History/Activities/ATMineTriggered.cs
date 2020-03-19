using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATMineTriggered : ActivityTooltipBuilder
{
    public ATMineTriggered(GameObject player, int value) : base(player, value)
    {
        BuildActivityTooltip();
    }

    public sealed override void BuildActivityTooltip()
    {
        tooltipMessage += player1Name;
        tooltipMessage += " Stepped on a mine.  ";
        tooltipMessage += value;
        tooltipMessage += " damage";
    }
}