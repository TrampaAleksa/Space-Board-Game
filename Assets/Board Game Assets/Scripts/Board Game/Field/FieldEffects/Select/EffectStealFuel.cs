using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectStealFuel : SelectPlayerEffect
{
    public const float AMOUNT_TO_STEAL = 20f;

    private void Awake()
    {
        selectionEffect = new StealFuel(gameObject);
    }

    public override void TriggerEffect()
    {
        GenericSelectTrigger();
        GenericTriggerEffect();
        print("Steal another players fuel!");
    }
}