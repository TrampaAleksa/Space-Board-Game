using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyField : FieldEffect , IGenericFieldEffect
{
    public override void TriggerEffect()
    {
        InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(gameObject);
        print("end turn");
    }

    public override void FinishedEffect()
    {
        DisplayInActivityHistory();
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
    
    private void DisplayInActivityHistory()
    {
        string message = new ATEmptyField(
            InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer()
        ).BuildActivityTooltip();
        InstanceManager.Instance.Get<ActivityHistoryHandler>().ShowActivityTooltipMessage(message);
    }
}