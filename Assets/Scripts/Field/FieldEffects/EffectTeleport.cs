using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTeleport : FieldEffect
{
    public override void TriggerEffect()
    {
        print("Emergency teleport!");
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}
