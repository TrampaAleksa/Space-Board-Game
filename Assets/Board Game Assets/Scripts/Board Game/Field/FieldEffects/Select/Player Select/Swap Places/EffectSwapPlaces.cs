using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSwapPlaces : SelectPlayerEffect
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
        GenericTriggerEffect();
        GenericSelectTrigger();
        print("Swap places with someone!");
    }

    public override void FinishedEffect()
    {
        throw new System.NotImplementedException();
    }
}