using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPlayerHealed : ActivityTooltipBuilder
{

    public ATPlayerHealed(GameObject player, int value) :base(player, value)
    {
        BuildActivityTooltip();
    }

    public sealed override void BuildActivityTooltip()
    {
        tooltipMessage += player1Name;
        tooltipMessage += " repaired for ";
        tooltipMessage += value;
        tooltipMessage += " health";
    }
}