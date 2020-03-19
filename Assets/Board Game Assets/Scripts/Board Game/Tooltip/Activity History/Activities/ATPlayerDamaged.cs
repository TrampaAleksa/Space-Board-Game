using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPlayerDamaged : ActivityTooltipBuilder
{
    public ATPlayerDamaged(GameObject player, int value) : base(player, value)
    {
        BuildActivityTooltip();
    }

    public sealed override void BuildActivityTooltip()
    {
        tooltipMessage += player1Name;
        tooltipMessage += " took ";
        tooltipMessage += value;
        tooltipMessage += " damage";
    }
}