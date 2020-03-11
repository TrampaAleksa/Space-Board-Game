﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectPlayerEffect : FieldEffect
{
    public void GenericSelectTrigger()
    {
        InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer(playersHandler.GetCurrentPlayer());
        InstanceManager.Instance.Get<Inputs>().selectionInputEvents += SelectionInputs;
        print(playersHandler.GetCurrentPlayer().name + " Is now choosing: ");
    }

    public void SelectionInputs()
    {
        print("input registered");
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer(playersHandler.GetCurrentPlayer());
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            selectionEffect?.ConfirmedSelection();
        }
    }

    public void FinishedSelecting()
    {
        InstanceManager.Instance.Get<Inputs>().selectionInputEvents
            -= SelectionInputs;
    }
}