using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTeleport : SelectFieldEffect
{
    public override void TriggerEffect()
    {
        print("Select a filed to teleport to!");
        GenericTriggerEffect();
        GenericSelectTrigger();
    }

    private void Awake()
    {
        selectionEffect = new TeleportFieldSelectionEffect();
    }
}