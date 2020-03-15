using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyField : FieldEffect
{
    public override void TriggerEffect()
    {
        GenericTriggerEffect();
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
        print("end turn");
    }

    public override void FinishedEffect()
    {
        throw new System.NotImplementedException();
    }
}