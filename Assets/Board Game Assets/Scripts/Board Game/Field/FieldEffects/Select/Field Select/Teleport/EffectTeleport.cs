using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTeleport : FieldEffect , IGenericFieldEffect
{
    private void Awake()
    {
        gameObject.AddComponent<GenericFieldSelectEffect>();
        gameObject.AddComponent<TeleportFieldSelectionEffect>();
    }

    public override void TriggerEffect()
    {
    }

    public override void FinishedEffect()
    {
    }
}