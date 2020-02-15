using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLockEnemy : FieldEffect
{
    public override void TriggerEffect()
    {
        print("Enemy can't move!");
    }
}
