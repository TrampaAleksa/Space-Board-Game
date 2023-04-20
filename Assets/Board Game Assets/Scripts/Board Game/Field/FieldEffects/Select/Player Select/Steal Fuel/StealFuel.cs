using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealFuel 
{

    public static bool TryStealingFuel(PlayerFuel triggeringPlayer, PlayerFuel selectedPlayer)
    {
        FuelHandler fuelHandler = InstanceManager.Instance.Get<FuelHandler>();
        AudioManager.Instance.PlaySound(AudioManager.STEAL_FUEL, false, 1);
        
        fuelHandler.AddFuelToPlayer(triggeringPlayer.gameObject, amountToSteal, true);
        fuelHandler.RemoveFuelFromPlayer(selectedPlayer.gameObject, amountToSteal, true);
        return true;
    }


    private static float amountToSteal => GameConfig.GetConfig<FuelConfig>().fuelToSteal;

}