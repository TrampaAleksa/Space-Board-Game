using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineFieldSelectionEvent : ISelectionEffect
{
    private GameObject fieldOfPlayerSelecting;

    public MineFieldSelectionEvent(GameObject fieldOfPlayerSelecting)
    {
        this.fieldOfPlayerSelecting = fieldOfPlayerSelecting;
    }

    public void ConfirmedSelection()
    {
        if (fieldOfPlayerSelecting.GetComponent<Mine>() == null)
        {
            fieldOfPlayerSelecting.AddComponent<Mine>();
            fieldOfPlayerSelecting.GetComponent<SelectEffect>().FinishedSelecting();
            InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
            //Mine placed sound
        }
        else Debug.Log("mine already exists");
    }
}