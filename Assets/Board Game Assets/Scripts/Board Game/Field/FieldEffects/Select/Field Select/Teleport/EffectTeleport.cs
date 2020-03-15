using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTeleport : SelectFieldEffect
{
    public override void TriggerEffect()
    {
        selectionEffect = new TeleportFieldSelectionEffect();
        print("Select a filed to teleport to!");
        GenericTriggerEffect();
        GenericSelectTrigger();
    }

    public override void FinishedEffect()
    {
        throw new System.NotImplementedException();
    }
}