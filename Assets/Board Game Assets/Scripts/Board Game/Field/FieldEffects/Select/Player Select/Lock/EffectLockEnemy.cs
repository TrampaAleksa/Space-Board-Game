using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLockEnemy : FieldEffect, IGenericFieldEffect
{
    public static int turnsToLock => GameConfig.GetConfig<EnginesConfig>().turnsToBreakOthersEngine;

    private void Awake()
    {
        gameObject.AddComponent<GenericPlayerSelectEffect>();
        gameObject.AddComponent<LockEnemySelectionEffect>();
    }

    public override void TriggerEffect()
    {
    }

    public override void FinishedEffect()
    {
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}