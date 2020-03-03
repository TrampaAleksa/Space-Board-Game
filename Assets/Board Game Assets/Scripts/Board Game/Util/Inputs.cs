using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer().GetComponent<PlayerCheckpoint>().RespawnAtCheckpoint();
        }
    }
}
