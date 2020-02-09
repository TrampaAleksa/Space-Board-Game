using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHandler : MonoBehaviour
{
    private void Start()
    {
        GameObject[] displayObjects = GameObject.FindGameObjectsWithTag("Display");
        LoopsHandler.LoopDelegate updateDelegate = null;
        foreach (var display in displayObjects)
        {
            updateDelegate += display.GetComponent<PlayerStateDisplay>().UpdateDisplay;
        }
        InstanceManager.Instance.Get<LoopsHandler>().Loop(0.2f, updateDelegate);
    }

}
