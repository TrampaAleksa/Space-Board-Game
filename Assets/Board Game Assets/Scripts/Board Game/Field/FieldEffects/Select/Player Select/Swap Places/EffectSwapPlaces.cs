using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSwapPlaces : SelectPlayerEffect
{
    public override void TriggerEffect()
    {
        GenericSelectTrigger();
        GenericTriggerEffect();
        print("Swap places with someone!");
    }

    private void Awake()
    {
        selectionEffect = new SwapPlaces(gameObject);
    }
}