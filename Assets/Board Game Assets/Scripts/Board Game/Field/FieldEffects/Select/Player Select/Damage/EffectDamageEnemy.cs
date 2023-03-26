using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamageEnemy : FieldEffect, IGenericFieldEffect
{
    public const float AMOUNT_TO_DAMAGE = 30f;

    private void Awake()
    {
        gameObject.AddComponent<GenericPlayerSelectEffect>();
        gameObject.AddComponent<DamageEnemySelectionEffect>();
    }

    public override void TriggerEffect()
    {
    }

    public override void FinishedEffect()
    {
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}