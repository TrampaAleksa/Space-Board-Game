using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHealPlayer : FieldEffect
{
    public float amountToHeal = 10;

    public override void TooltipDisplay()
    {
        TooltipHandler tooltipHandler = InstanceManager.Instance.Get<TooltipHandler>();
        tooltipHandler.ShowTooltip(tooltipHandler.fieldInfoTooltip, "You were repaired!");
    }
    public override void TriggerEffect()
    {
        Repair.RepairPlayer(playersHandler.GetCurrentPlayer(), amountToHeal, HullHandler.MAXIMUM_HULL);
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }

}
