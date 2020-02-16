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

    public static bool TryStealingFuel(PlayerFuel triggeringPlayer, PlayerFuel selectedPlayer, float amountToSteal, GameObject fieldTriggeringEffect)
    {
        FuelHandler fuelHandler = InstanceManager.Instance.Get<FuelHandler>();
        fuelHandler.AddFuelToPlayer(triggeringPlayer.gameObject, amountToSteal);
        fuelHandler.RemoveFuelFromPlayer(selectedPlayer.gameObject, amountToSteal);
        fieldTriggeringEffect.tag = "Untagged";
        return true;
    }

    public void ConfirmedSelection()
    {
        PlayersHandler playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
        PlayerFuel triggeringPlayer = playersHandler.GetCurrentPlayer().GetComponent<PlayerFuel>();
        PlayerFuel selectedPlayer = InstanceManager.Instance.Get<SelectionHandler>().GetSelectedPlayer().GetComponent<PlayerFuel>();
        if (TryStealingFuel(triggeringPlayer, selectedPlayer, EffectStealFuel.AMOUNT_TO_STEAL, field))
            InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}
