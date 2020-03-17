using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelStation : FieldEffect, IGenericFieldEffect
{
    private float fuelPerVisit = 20f;

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
            DisplayInActivityHistory();
            InstanceManager.Instance.Get<FuelHandler>().AddFuelToPlayer(other.gameObject, fuelPerVisit, true);
            //Fuel added sound?
        }
    }

    public override void FinishedEffect()
    {
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }

    private void DisplayInActivityHistory()
    {
        string message = new ATPlayerFuel(
           InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer(),
           (int)fuelPerVisit
           ).BuildActivityTooltip();
        InstanceManager.Instance.Get<ActivityHistoryHandler>().ShowActivityTooltipMessage(message);
    }
}