using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyField : FieldEffect
{
    public override void TriggerEffect()
    {
        GenericTriggerEffect();
        InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(gameObject);
        print("end turn");
    }

    public override void FinishedEffect()
    {
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}