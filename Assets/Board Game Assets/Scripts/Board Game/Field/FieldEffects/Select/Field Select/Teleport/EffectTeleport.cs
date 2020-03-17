using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTeleport : SelectFieldEffect , IGenericFieldEffect
{
    public override void TriggerEffect()
    {
        selectionEffect = new TeleportFieldSelectionEffect();
        print("Select a filed to teleport to!");
        GenericSelectTrigger();
    }

    public override void FinishedEffect()
    {
        gameObject.GetComponent<SelectEffect>().FinishedSelecting();
    }
}