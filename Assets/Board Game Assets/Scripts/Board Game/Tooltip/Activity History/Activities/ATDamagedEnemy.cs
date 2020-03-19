using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATDamagedEnemy : ActivityTooltipBuilder
{
    public ATDamagedEnemy(GameObject player1, GameObject player2, int value) : base(player1, player2, value)
    {
        BuildActivityTooltip();
    }

    public sealed override void BuildActivityTooltip()
    {
        tooltipMessage += player1Name;
        tooltipMessage += " dealt " + value;
        tooltipMessage += " damage to ";
        tooltipMessage += player2Name;
    }
}