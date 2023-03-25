using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlaceMine : FieldEffect , IGenericFieldEffect
{

    public GameObject mineObj;
    private void Awake()
    {
        gameObject.AddComponent<GenericFieldSelectEffect>();
        gameObject.AddComponent<MineFieldSelectionEvent>()
            .SetMineObj(mineObj);
    }

    public override void TriggerEffect()
    {
    }

    public override void FinishedEffect()
    {
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }

  
}