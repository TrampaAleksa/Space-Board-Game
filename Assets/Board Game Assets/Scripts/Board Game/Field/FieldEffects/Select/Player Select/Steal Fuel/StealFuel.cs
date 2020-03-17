using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealFuel : ISelectionEffect
{
    private GameObject field;

    public StealFuel(GameObject field)
    {
        this.field = field;
    }

    public static bool TryStealingFuel(PlayerFuel triggeringPlayer, PlayerFuel selectedPlayer, GameObject fieldTriggeringEffect)
    {
        fieldTriggeringEffect.GetComponent<SelectPlayerEffect>().FinishedSelecting();
        FuelHandler fuelHandler = InstanceManager.Instance.Get<FuelHandler>();
        fuelHandler.AddFuelToPlayer(triggeringPlayer.gameObject, EffectStealFuel.AMOUNT_TO_STEAL, true);
        fuelHandler.RemoveFuelFromPlayer(selectedPlayer.gameObject, EffectStealFuel.AMOUNT_TO_STEAL, true);
        return true;
    }

    public void ConfirmedSelection()
    {
        PlayersHandler playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
        PlayerFuel triggeringPlayer = playersHandler.GetCurrentPlayer().GetComponent<PlayerFuel>();
        PlayerFuel selectedPlayer = InstanceManager.Instance.Get<SelectionHandler>().GetSelectedPlayer().GetComponent<PlayerFuel>();
        if (TryStealingFuel(triggeringPlayer, selectedPlayer, field)){
            DisplayInActivityHistory();
            InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(field);
        }
    }

     private void DisplayInActivityHistory()
    {
        string message = new ATStealFuel(
           InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer(),
           InstanceManager.Instance.Get<SelectionHandler>().GetSelectedPlayer(),
           (int)EffectStealFuel.AMOUNT_TO_STEAL
           ).BuildActivityTooltip();
        InstanceManager.Instance.Get<ActivityHistoryHandler>().ShowActivityTooltipMessage(message);
    }
}