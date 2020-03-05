using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSwapPlaces : SelectOnTrigger
{
    public override void TriggerEffect()
    {
        SelectNextPlayerOnTrigger();
        GenericTriggerEffect();
        print("Swap places with someone!");
    }

    private void Awake()
    {
        selectionEffect = new SwapPlaces(gameObject);
    }

    private void Update()
    {
        if (gameObject.tag == TAG_SELECTION)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer(playersHandler.GetCurrentPlayer());
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                selectionEffect.ConfirmedSelection();
            }
        }
    }
}