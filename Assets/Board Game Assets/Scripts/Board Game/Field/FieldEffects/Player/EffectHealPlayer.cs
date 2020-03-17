using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHealPlayer : FieldEffect, IGenericFieldEffect
{
    public float amountToHeal = 20f;

    public override void TriggerEffect()
    {
        Repair.RepairPlayer(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer(), amountToHeal, HullHandler.MAXIMUM_HULL);
        InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(gameObject);
    }

    public override void FinishedEffect()
    {
        DisplayInActivityHistory();
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }

    private void DisplayInActivityHistory()
    {
        string message = new ATPlayerHealed(
           InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer(),
           (int)amountToHeal
           ).BuildActivityTooltip();
        InstanceManager.Instance.Get<ActivityHistoryHandler>().ShowActivityTooltipMessage(message);
    }
}