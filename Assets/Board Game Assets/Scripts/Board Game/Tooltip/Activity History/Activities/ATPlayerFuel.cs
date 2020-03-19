using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPlayerFuel : ActivityTooltipBuilder
{

    public ATPlayerFuel(GameObject player, int value) :base(player, value)
    {
        BuildActivityTooltip();
    }

    public sealed override void BuildActivityTooltip()
    {
        tooltipMessage += player1Name;
        tooltipMessage += " visited fuel station. Gained ";
        tooltipMessage += value;
        tooltipMessage += " fuel";
    }
}