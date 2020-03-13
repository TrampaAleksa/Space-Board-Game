﻿using System;
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
        GenericSelectTrigger();
        GenericTriggerEffect();
        print("Swap places with someone!");
    }

    private void Awake()
    {
        selectionEffect = new SwapPlaces(gameObject);
    }
}