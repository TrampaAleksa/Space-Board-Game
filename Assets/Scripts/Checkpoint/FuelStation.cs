using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelStation : FieldEffect
{
    private float fuelPerVisit = 20f;
    public override void TriggerEffect()
    {
        GameObject player = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer();
        Field field = gameObject.GetComponent<Field>();
        InstanceManager.Instance.Get<CheckpointHandler>().SetPlayersCheckpoint(player, field);
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerFuel>().fuel += fuelPerVisit;
            print("added fuel to: " + other.name);
        }
    }

}
