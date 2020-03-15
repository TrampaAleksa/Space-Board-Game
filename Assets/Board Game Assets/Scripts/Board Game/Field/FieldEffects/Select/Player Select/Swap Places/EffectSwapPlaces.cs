using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSwapPlaces : SelectPlayerEffect, IGenericFieldEffect
{
    public override void TriggerEffect()
    {
        if (PlayersSameField.AllPlayersOnSameField())
        {
            InstanceManager.Instance.Get<TooltipHandler>().ShowInfoTooltip("All players are on the same field!");
            InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
            return;
        }
        selectionEffect = new SwapPlaces(gameObject);
        GenericSelectTrigger();
        print("Swap places with someone!");
    }

    public override void FinishedEffect()
    {
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}