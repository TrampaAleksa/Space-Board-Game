using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPlayerLocked : ActivityTooltipBuilder
{
    public ATPlayerLocked(GameObject player, int value) : base(player, value)
    {
        BuildActivityTooltip();
    }

    public sealed override void BuildActivityTooltip()
    {
        tooltipMessage += player1Name;
        tooltipMessage += " engines broken for ";
        tooltipMessage += value;
        tooltipMessage += " turn(s)";
    }
}