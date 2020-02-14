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
        //TODO -- Extrack TeleportToField method to use in some of the cases
        InstanceManager.Instance.Get<FieldHandler>().SetCurrentField(CheckpointField, player);
        player.transform.position = playerMovement.positionToTravelTo;
        return player;
    }

}
