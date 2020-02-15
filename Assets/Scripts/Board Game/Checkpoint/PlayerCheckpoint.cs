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
        player.GetComponent<PlayerHull>().hullPercentage = HullHandler.startingAmount;
        playerMovement.turnsToSkip = 0;
        return player;
    }

}
