using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHandler : MonoBehaviour
{
 
    void Start()
    {
        LoopsHandler.LoopDelegate loopDelegate = null;
        GameObject[] displays = GameObject.FindGameObjectsWithTag("Display");
        foreach (var display in displays)
        {
            loopDelegate += display.GetComponent<PlayerStateDisplay>().UpdateDisplay;
        }
        InstanceManager.Instance.Get<LoopsHandler>().Loop(0.2f, loopDelegate);
    }

}
