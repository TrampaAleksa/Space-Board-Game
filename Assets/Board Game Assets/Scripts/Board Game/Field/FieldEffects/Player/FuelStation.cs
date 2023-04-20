using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelStation : FieldEffect, IGenericFieldEffect
{
    public override void TriggerEffect()
    {
        GameObject player = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer();
        Field field = gameObject.GetComponent<Field>();
        InstanceManager.Instance.Get<CheckpointHandler>().SetPlayersCheckpoint(player, field);
        InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DisplayInActivityHistory(other.gameObject);
            InstanceManager.Instance.Get<FuelHandler>().AddFuelToPlayer(other.gameObject, fuelPerVisit, true);
            AudioManager.Instance.PlaySound(AudioManager.REFILL, false, 1);
        }
    }

    public override void FinishedEffect()
    {
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }

    private void DisplayInActivityHistory(GameObject player)
    {
        new ATFuelStation(player, (int)fuelPerVisit).DisplayAT();
    }

    private static float fuelPerVisit => GameConfig.GetConfig<FuelConfig>().fuelPerCheckpoint;
}