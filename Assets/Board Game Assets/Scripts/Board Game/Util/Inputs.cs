using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public event Action selectionInputEvents;

    private int i = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer().GetComponent<PlayerCheckpoint>().RespawnAtCheckpoint();
        }
        selectionInputEvents?.Invoke();
        if (Input.GetKeyDown(KeyCode.T))
        {
            InstanceManager.Instance.Get<ActivityHistoryHandler>().ShowActivityTooltipMessage("He<color=cyan>llo</color>");
            i++;
        }
    }
}