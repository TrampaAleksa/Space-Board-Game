﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockEnemy : ISelectionEffect
{
    private GameObject field;

    public LockEnemy(GameObject field)
    {
        this.field = field;
    }

    public static bool TrySkippingPlayersTurn(PlayerMovement selectedPlayer, int numberOfTurns, GameObject fieldTriggeringEffect)
    {
        fieldTriggeringEffect.GetComponent<SelectPlayerEffect>().FinishedSelecting();
        TurnHandler turnHandler = InstanceManager.Instance.Get<TurnHandler>();
        turnHandler.AddPlayerTurnsToSkip(selectedPlayer.gameObject, numberOfTurns);

        return true;
    }

    public void ConfirmedSelection()
    {
        PlayerMovement selectedPlayer = InstanceManager.Instance.Get<SelectionHandler>().GetSelectedPlayer().GetComponent<PlayerMovement>();
        if (TrySkippingPlayersTurn(selectedPlayer, EffectLockEnemy.TURNS_TO_LOCK, field))
        {
            DisplayInActivityHistory();
            InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(field);
        }
    }
    
    private void DisplayInActivityHistory()
    {
        string message = new ATEnemyLock(
            InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer(),
            InstanceManager.Instance.Get<SelectionHandler>().GetSelectedPlayer()
        ).BuildActivityTooltip();
        InstanceManager.Instance.Get<ActivityHistoryHandler>().ShowActivityTooltipMessage(message);
    }
}