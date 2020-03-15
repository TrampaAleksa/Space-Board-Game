using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamageEnemy : SelectPlayerEffect
{
    public const float AMOUNT_TO_DAMAGE = 40f;

    public override void TriggerEffect()
    {
        selectionEffect = new DamageEnemy(gameObject);
        GenericSelectTrigger();
        GenericTriggerEffect();
        print("Damage Another player!");
    }

    public override void FinishedEffect()
    {
        throw new System.NotImplementedException();
    }
}