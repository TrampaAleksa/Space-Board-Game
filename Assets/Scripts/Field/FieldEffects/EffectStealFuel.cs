using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectStealFuel : FieldEffect
{
    public override void TriggerEffect()
    {
        print("Steam the enemy's fuel");
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}
