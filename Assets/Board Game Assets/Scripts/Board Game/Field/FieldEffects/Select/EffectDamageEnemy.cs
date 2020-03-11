using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamageEnemy : SelectPlayerEffect
{
    public const float AMOUNT_TO_DAMAGE = 20f;

    public override void TriggerEffect()
    {
        GenericSelectTrigger();
        GenericTriggerEffect();
        print("Damage Another player!");
    }

    private void Awake()
    {
        selectionEffect = new DamageEnemy(gameObject);
    }
}