using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineFieldSelectionEvent
{
    public void ConfirmSelectedField(GameObject field)
    {
        if (field.GetComponent<Mine>() == null)
        {
            field.AddComponent<Mine>();
            InstanceManager.Instance.Get<FieldSelectionHandler>().confirmedSelectionEvents -= ConfirmSelectedField;
            InstanceManager.Instance.Get<PlayersHandler>()
                .GetCurrentPlayer()
                .GetComponent<PlayerMovement>()
                .currentPlayerField
                .GetComponent<SelectFieldEffect>()
                .FinishedSelecting();
            InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
            //Mine placed sound
        }
        else Debug.Log("mine already exists");
    }
}