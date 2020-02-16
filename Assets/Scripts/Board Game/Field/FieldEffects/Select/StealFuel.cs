using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealFuel 
{
    public static bool TryStealingFuel(PlayerFuel triggeringPlayer, PlayerFuel selectedPlayer, float amountToSteal, GameObject fieldTriggeringEffect)
    {
        FuelHandler fuelHandler = InstanceManager.Instance.Get<FuelHandler>();
        fuelHandler.AddFuelToPlayer(triggeringPlayer.gameObject, amountToSteal);
        fuelHandler.RemoveFuelFromPlayer(selectedPlayer.gameObject, amountToSteal);
        fieldTriggeringEffect.tag = "Untagged";
        return true;
    }
}
