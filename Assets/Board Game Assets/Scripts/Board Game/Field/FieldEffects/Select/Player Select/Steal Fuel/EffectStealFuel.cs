using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectStealFuel : FieldEffect, IGenericFieldEffect
{
    public const float AMOUNT_TO_STEAL = 20f;

    private void Awake()
    {
        gameObject.AddComponent<GenericPlayerSelectEffect>();
        gameObject.AddComponent<StealFuelSelectionEffect>();
    }

    public override void TriggerEffect()
    {
    }

    public override void FinishedEffect()
    {        
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}