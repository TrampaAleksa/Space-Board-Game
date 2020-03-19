using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATRespawn : ActivityTooltipBuilder
{

    public ATRespawn(GameObject player) : base(player)
    {
        BuildActivityTooltip();
    }

    public sealed override void BuildActivityTooltip()
    {
        tooltipMessage += player1Name;
        tooltipMessage += " Destroyed. Respawned with  ";
        tooltipMessage += value;
         tooltipMessage += " fuel  ";
    }
}
