using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamageEnemy : SelectPlayerEffect, IGenericFieldEffect
{
    public const float AMOUNT_TO_DAMAGE = 40f;

    public override void TriggerEffect()
    {
        selectionEffect = new DamageEnemy(gameObject);
        GenericSelectTrigger();
        print("Damage Another player!");
    }

    public override void FinishedEffect()
    {
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}