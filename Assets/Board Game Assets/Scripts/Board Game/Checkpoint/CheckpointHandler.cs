using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour, IBoardPlayerState
{
    public void SetPlayersCheckpoint(GameObject player, Field fieldToSetTo)
    {
        player.GetComponent<PlayerCheckpoint>().CheckpointField = fieldToSetTo;
        print("Set the checkpoint for : " + player.name + ", field : " + fieldToSetTo.name);
    }

    public void SetPlayerStatusAfterRespawn(GameObject player)
    {
        player.GetComponent<PlayerHull>().HullPercentage = HullHandler.STARTING_HULL;
        player.GetComponent<PlayerMovement>().turnsToSkip = 0;
        float numberToDivideFuelBy = 2f;
        player.GetComponent<PlayerFuel>().fuel /= numberToDivideFuelBy;
    }

    public void SavePlayerState(GameObject player, PlayerBoardState playerState)
    {
        int checkpointIndex = player.GetComponent<PlayerCheckpoint>().CheckpointField.IndexInPath;
        playerState.checkpointIndex = checkpointIndex;
    }

    public void SetupPlayerState(GameObject player, PlayerBoardState playerState)
    {
        int checkpointIndex = playerState.checkpointIndex;
        Field fieldAtCheckpointIndex = InstanceManager.Instance.Get<FieldHandler>().MemberWithIndex(checkpointIndex).GetComponent<Field>();
        player.GetComponent<PlayerCheckpoint>().CheckpointField = fieldAtCheckpointIndex;
    }
}