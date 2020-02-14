﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour, IBoardState
{
    public void SaveState()
    {
        int i = 0;
        foreach (var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            int checkpointIndex = player.GetComponent<PlayerCheckpoint>().checkpointField.IndexInPath;
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
            player.GetComponent<PlayerCheckpoint>().checkpointField = fieldAtCheckpointIndex;
            i++;
        }
    }

}