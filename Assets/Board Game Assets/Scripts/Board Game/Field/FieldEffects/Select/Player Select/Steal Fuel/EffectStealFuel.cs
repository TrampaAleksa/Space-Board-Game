﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectStealFuel : SelectPlayerEffect, IGenericFieldEffect
{
    public const float AMOUNT_TO_STEAL = 20f;

    public override void TriggerEffect()
    {
        selectionEffect = new StealFuel(gameObject);
        GenericSelectTrigger();
        print("Steal another players fuel!");
    }

    public override void FinishedEffect()
    {
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}