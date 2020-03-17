using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLockEnemy : SelectPlayerEffect, IGenericFieldEffect
{
    public const int TURNS_TO_LOCK = 1;

    public override void TriggerEffect()
    {
        selectionEffect = new LockEnemy(gameObject);
        GenericSelectTrigger();
        print("Break another players engines!");
    }

    public override void FinishedEffect()
    {
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}