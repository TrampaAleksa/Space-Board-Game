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

        InstanceManager.Instance.Get<FieldHandler>().TeleportPlayerToField(player, CheckpointField);
        InstanceManager.Instance.Get<CheckpointHandler>().SetPlayerStatusAfterRespawn(player);
        DisplayInActivityHistory(player);
        return player;
    }

     private void DisplayInActivityHistory(GameObject player)
    {
        new ATRespawn(player).DisplayAT();
    }
}