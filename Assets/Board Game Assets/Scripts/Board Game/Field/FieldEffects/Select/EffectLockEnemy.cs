using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLockEnemy : SelectPlayerEffect
{
    public const int TURNS_TO_LOCK = 1;

    public override void TriggerEffect()
    {
        GenericSelectTrigger();
        GenericTriggerEffect();
        print("Break another players engines!");
    }

    private void Awake()
    {
        selectionEffect = new LockEnemy(gameObject);
    }
}