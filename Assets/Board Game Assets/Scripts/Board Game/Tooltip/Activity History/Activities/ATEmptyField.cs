using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATEmptyField : ActivityTooltipBuilder
{
    public ATEmptyField(GameObject player) : base(player)
    {
        BuildActivityTooltip();
    }

    public sealed override void BuildActivityTooltip()
    {
        tooltipMessage += player1Name;
        tooltipMessage += " landed on an empty field ";
    }
}

