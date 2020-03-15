using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlaceMine : SelectFieldEffect , IGenericFieldEffect
{
    public override void TriggerEffect()
    {
        selectionEffect = new MineFieldSelectionEvent(gameObject);
        print("Place a mine!");
        GenericSelectTrigger();
    }

    public override void FinishedEffect()
    {
        gameObject.GetComponent<SelectEffect>().FinishedSelecting();
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}