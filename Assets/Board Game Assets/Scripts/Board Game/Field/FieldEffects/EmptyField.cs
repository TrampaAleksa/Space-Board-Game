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
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}