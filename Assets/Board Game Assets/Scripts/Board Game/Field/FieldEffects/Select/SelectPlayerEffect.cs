using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectPlayerEffect : SelectEffect
{
    public override void GenericSelectTrigger()
    {
        InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer());
        InstanceManager.Instance.Get<Inputs>().selectionInputEvents += SelectionInputs;
        print(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer().name + " Is now choosing: ");
    }

    public override void SelectionInputs()
    {
        print("input registered");
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AudioManager.Instance.PlaySound("shortClick");
            InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer());
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            AudioManager.Instance.PlaySound("shortClick");
            selectionEffect?.ConfirmedSelection();
        }
    }

    public override void FinishedSelecting()
    {
        InstanceManager.Instance.Get<Inputs>().selectionInputEvents
            -= SelectionInputs;
    }
}