using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    public Field checkpointField;

    public GameObject RespawnAtCheckpoint()
    {
        GameObject player = gameObject;
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        //TODO -- Extrack TeleportToField method to use in some of the cases
        InstanceManager.Instance.Get<FieldHandler>().SetCurrentField(checkpointField, player);
        player.transform.position = playerMovement.positionToTravelTo;
        return player;
    }

}
