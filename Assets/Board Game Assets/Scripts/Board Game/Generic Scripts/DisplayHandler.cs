using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHandler : MonoBehaviour
{

    public Func<bool> loopDelegate;
    public GameObject[] displays;
    void Start()
    {
        displays = GameObject.FindGameObjectsWithTag("Display");
        foreach (var display in displays)
        {
            loopDelegate += display.GetComponent<PlayerStateDisplay>().UpdateDisplay;
        }
        InstanceManager.Instance.Get<LoopsHandler>().Loop(0.2f, loopDelegate);
    }

    public void SetShouldUpdate()
    {
        foreach (var display in displays)
        {
            PlayerHullDisplayBar displayBar = display.GetComponent<PlayerHullDisplayBar>();
            if (displayBar != null)
            {
                displayBar.shouldUpdate = true;
            }
        }
    }

}
