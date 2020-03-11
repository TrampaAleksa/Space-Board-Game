using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlaceMine : SelectFieldEffect
{
    public override void TriggerEffect()
    {
        print("Place a mine!");
        GenericTriggerEffect();
        GenericSelectTrigger();
        MineFieldSelectionEvent fieldSelectionEvent = new MineFieldSelectionEvent();
        InstanceManager.Instance.Get<FieldSelectionHandler>().confirmedSelectionEvents += fieldSelectionEvent.ConfirmSelectedField;
    }
}