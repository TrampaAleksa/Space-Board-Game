using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATMinePlacement : ActivityTooltipBuilder
{
    public ATMinePlacement(GameObject player) : base(player)
    {
        BuildActivityTooltip();
    }

    public sealed override void BuildActivityTooltip()
    {
        tooltipMessage += player1Name;
        tooltipMessage += " placed a mine ";
    }
}
