using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    private Field checkpointField;

    public Field CheckpointField { get => checkpointField; set => checkpointField = value; }

    public GameObject RespawnAtCheckpoint()
    {
        GameObject player = gameObject;
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        InstanceManager.Instance.Get<FieldHandler>().TeleportPlayerToField(player, CheckpointField);
        player.GetComponent<PlayerHull>().HullPercentage = HullHandler.STARTING_HULL;
        playerMovement.turnsToSkip = 0;
        float numberToDivideFuelBy = 2f;
        player.GetComponent<PlayerFuel>().fuel /= numberToDivideFuelBy;
        return player;
    }

}
