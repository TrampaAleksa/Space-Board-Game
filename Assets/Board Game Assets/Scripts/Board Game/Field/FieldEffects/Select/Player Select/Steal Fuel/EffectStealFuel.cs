using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectStealFuel : SelectPlayerEffect
{
    public const float AMOUNT_TO_STEAL = 20f;

    public override void TriggerEffect()
    {
        selectionEffect = new StealFuel(gameObject);
        GenericSelectTrigger();
        GenericTriggerEffect();
        print("Steal another players fuel!");
    }
}