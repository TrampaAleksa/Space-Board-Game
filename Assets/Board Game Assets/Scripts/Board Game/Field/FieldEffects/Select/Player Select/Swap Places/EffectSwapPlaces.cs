using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSwapPlaces : FieldEffect, IGenericFieldEffect
{
    private void Awake()
    {
        gameObject.AddComponent<GenericPlayerSelectEffect>();
        gameObject.AddComponent<SwapPlacesSelectionEvent>();
    }

    public override void TriggerEffect()
    {
        if (PlayersSameField.AllPlayersOnSameField())
        {
            InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(gameObject);
            InstanceManager.Instance.Get<TooltipHandler>().ShowInfoTooltip("All players are on the same field!");
        }
    }

    public override void FinishedEffect()
    {
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}