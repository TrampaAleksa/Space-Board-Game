using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectStealFuel : FieldEffect, IGenericFieldEffect
{
    public const float AMOUNT_TO_STEAL = 20f;

    private void Start()
    {
        gameObject.AddComponent<GenericPlayerSelectEffect>();
        gameObject.AddComponent<StealFuelFieldEffect>();
    }

    public override void TriggerEffect()
    {
    }

    public override void FinishedEffect()
    {
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}