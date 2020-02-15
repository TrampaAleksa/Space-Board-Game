using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLock : FieldEffect
{
    public override void TriggerEffect()
    {
        print("Your engines shut down!");
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}
