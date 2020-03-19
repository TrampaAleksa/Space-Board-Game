using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATTeleported : ActivityTooltipBuilder
{
    public ATTeleported(GameObject player) :base(player)
    {
        BuildActivityTooltip();
    }

    public sealed override void BuildActivityTooltip()
    {
        tooltipMessage += player1Name;
        tooltipMessage += " teleported to another field ";
    }
}
