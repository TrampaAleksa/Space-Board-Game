using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public event Action selectionInputEvents;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer().GetComponent<PlayerCheckpoint>().RespawnAtCheckpoint();
        }
        selectionInputEvents?.Invoke();
    }
}