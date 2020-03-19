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
        new ATEmptyField(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer()
        ).DisplayAT();
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
  
}