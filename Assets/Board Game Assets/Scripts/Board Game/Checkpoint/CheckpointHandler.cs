using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{
    public void SetPlayersCheckpoint(GameObject player, Field fieldToSetTo)
    {
        player.GetComponent<PlayerCheckpoint>().CheckpointField = fieldToSetTo;
        new ATCheckpoint(player).DisplayAT();
    }

    public void SetPlayerStatusAfterRespawn(GameObject player)
    {
        player.GetComponent<PlayerHull>().HullPercentage = HullHandler.startingHull;
        player.GetComponent<PlayerMovement>().turnsToSkip = 0;
        float numberToDivideFuelBy = 2f;
        player.GetComponent<PlayerFuel>().fuel /= numberToDivideFuelBy;
    }

}