using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlaceMine : FieldEffect , IGenericFieldEffect
{
    private void Awake()
    {
        gameObject.AddComponent<GenericFieldSelectEffect>();
        gameObject.AddComponent<MineFieldSelectionEvent>();
    }

    public override void TriggerEffect()
    {
    }

    public override void FinishedEffect()
    {
       // gameObject.GetComponent<SelectEffect>().FinishedSelecting();
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }

  
}