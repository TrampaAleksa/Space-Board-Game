using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectStealFuel : FieldEffect
{
    public float amountToSteal = 20f;
    public override void TriggerEffect()
    {
        gameObject.tag = TAG_SELECTION;
        InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer(playersHandler.GetCurrentPlayer());
        print(playersHandler.GetCurrentPlayer().name + " Is now choosing: ");
        print("Steal another players fuel!");
    }

    private void Update()
    {
        if (gameObject.tag == TAG_SELECTION)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer(playersHandler.GetCurrentPlayer());
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                PlayerFuel triggeringPlayer = playersHandler.GetCurrentPlayer().GetComponent<PlayerFuel>();
                PlayerFuel selectedPlayer = InstanceManager.Instance.Get<SelectionHandler>().GetSelectedPlayer().GetComponent<PlayerFuel>();
                if (TryStealingFuel(triggeringPlayer, selectedPlayer))
                    InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
            }
        }

    }

    public bool TryStealingFuel(PlayerFuel triggeringPlayer, PlayerFuel selectedPlayer)
    {
        FuelHandler fuelHandler = InstanceManager.Instance.Get<FuelHandler>();
        fuelHandler.AddFuelToPlayer(triggeringPlayer.gameObject, amountToSteal);
        fuelHandler.RemoveFuelFromPlayer(selectedPlayer.gameObject, amountToSteal);
        gameObject.tag = "Untagged";
        return true;
    }
}
