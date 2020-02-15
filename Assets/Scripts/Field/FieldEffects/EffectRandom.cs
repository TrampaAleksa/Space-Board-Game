using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRandom : FieldEffect
{
    public override void TriggerEffect()
    {
        print("Random effect!");
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}
