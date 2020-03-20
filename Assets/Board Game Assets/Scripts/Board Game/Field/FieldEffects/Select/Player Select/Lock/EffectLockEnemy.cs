using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLockEnemy : FieldEffect, IGenericFieldEffect
{
    public const int TURNS_TO_LOCK = 1;


    private void Awake()
    {
        gameObject.AddComponent<GenericPlayerSelectEffect>();
        gameObject.AddComponent<LockEnemyFieldEffect>();
    }

    public override void TriggerEffect()
    {
    }

    public override void FinishedEffect()
    {
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}