using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLockPlayer : FieldEffect, IGenericFieldEffect
{
    public const int NUMBER_OF_TURNS = 1;

    public override void TriggerEffect()
    {
        InstanceManager.Instance.Get<TurnHandler>().AddPlayerTurnsToSkip(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer(), NUMBER_OF_TURNS);
        InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(gameObject);
    }

    public override void FinishedEffect()
    {
        DisplayInActivityHistory();
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }

    private void DisplayInActivityHistory()
    {
        string message = new ATPlayerLocked(
           InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer(),
           NUMBER_OF_TURNS
           ).BuildActivityTooltip();
        InstanceManager.Instance.Get<ActivityHistoryHandler>().ShowActivityTooltipMessage(message);
    }
}