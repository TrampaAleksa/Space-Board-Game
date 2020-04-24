using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealFuelSelectionEffect : MonoBehaviour, ISelectionEffect
{
    public void ConfirmedSelection()
    {
        PlayersHandler playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
        PlayerFuel triggeringPlayer = playersHandler.GetCurrentPlayer().GetComponent<PlayerFuel>();
        PlayerFuel selectedPlayer = InstanceManager.Instance.Get<SelectionHandler>().GetSelectedPlayer()
            .GetComponent<PlayerFuel>();

        if (StealFuel.TryStealingFuel(triggeringPlayer, selectedPlayer))
        {
            DisplayInActivityHistory(triggeringPlayer.gameObject, selectedPlayer.gameObject);
            InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
        }
        
    }

    private void DisplayInActivityHistory(GameObject triggeringPlayer, GameObject selectedPlayer)
    {
        new ATStealFuel(
            triggeringPlayer,
            selectedPlayer,
            (int) EffectStealFuel.AMOUNT_TO_STEAL
        ).DisplayAT();
    }
}