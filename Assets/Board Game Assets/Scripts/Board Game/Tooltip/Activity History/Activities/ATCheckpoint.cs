using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATCheckpoint : ActivityTooltipBuilder
{

    public ATCheckpoint(GameObject player) : base(player)
    {
        BuildActivityTooltip();
    }

    public sealed override void BuildActivityTooltip()
    {
        tooltipMessage += player1Name;
        tooltipMessage += " got a checkpoint  ";
    }
}
