using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCheckpointInit : MonoBehaviour, IBoardStateInitializer
{
    public void SavePlayerState(GameObject player, PlayerBoardState playerState)
    {
        int checkpointIndex = player.GetComponent<PlayerCheckpoint>().CheckpointField.IndexInPath;
        playerState.checkpointIndex = checkpointIndex;
    }

    public void SetupPlayerState(GameObject player, PlayerBoardState playerState)
    {
        int checkpointIndex = playerState.checkpointIndex;
        Field fieldAtCheckpointIndex = InstanceManager.Instance.Get<FieldHandler>().MemberWithIndex(checkpointIndex)
            .GetComponent<Field>();
        player.GetComponent<PlayerCheckpoint>().CheckpointField = fieldAtCheckpointIndex;
    }
}