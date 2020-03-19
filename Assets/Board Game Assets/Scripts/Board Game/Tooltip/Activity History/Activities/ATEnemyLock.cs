using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATEnemyLock : ActivityTooltipBuilder
{
    public ATEnemyLock(GameObject player1, GameObject player2) : base(player1, player2)
    {
        BuildActivityTooltip();
    }

    public sealed override void BuildActivityTooltip()
    {
        tooltipMessage += player1Name;
        tooltipMessage += " broke ";
        tooltipMessage += player2Name;
        tooltipMessage += "'s engines";
    }
}