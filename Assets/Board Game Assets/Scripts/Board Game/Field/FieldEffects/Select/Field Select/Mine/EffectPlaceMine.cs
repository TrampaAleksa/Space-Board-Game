using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlaceMine : SelectFieldEffect
{
    public override void TriggerEffect()
    {
        selectionEffect = new MineFieldSelectionEvent(gameObject);
        print("Place a mine!");
        GenericTriggerEffect();
        GenericSelectTrigger();
    }

    public override void FinishedEffect()
    {
    }
}