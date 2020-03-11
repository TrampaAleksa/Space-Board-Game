using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour, IBoardState
{
    public void SaveState()
    {
        int i = 0;
        foreach (var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            int checkpointIndex = player.GetComponent<PlayerCheckpoint>().CheckpointField.IndexInPath;
            InstanceManager.Instance.Get<BoardStateHandler>().playerBoardStates[i].checkpointIndex = checkpointIndex;
            i++;
        }
    }

    public void SetupState()
    {
        int i = 0;
        foreach (var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            int checkpointIndex = InstanceManager.Instance.Get<BoardStateHandler>().playerBoardStates[i].checkpointIndex;
            Field fieldAtCheckpointIndex = InstanceManager.Instance.Get<FieldHandler>().MemberWithIndex(checkpointIndex).GetComponent<Field>();
            player.GetComponent<PlayerCheckpoint>().CheckpointField = fieldAtCheckpointIndex;
            i++;
        }
    }

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
}