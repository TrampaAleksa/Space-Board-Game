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
        GameObject selectedField = InstanceManager.Instance.Get<FieldSelectionHandler>().GetSelectedField();
        if (selectedField.GetComponent<Mine>() == null)
        {
            selectedField.AddComponent<Mine>();
            DisplayInActivityHistory();
            InstanceManager.Instance.Get<FieldEffectHandler>().AddEffectToField(selectedField, selectedField.GetComponent<Mine>());
            InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(fieldOfPlayerSelecting);
            //Mine placed sound
        }
        else Debug.Log("mine already exists");
    }
    
    private void DisplayInActivityHistory()
    {
        string message = new ATMinePlacement(
            InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer()
        ).BuildActivityTooltip();
        InstanceManager.Instance.Get<ActivityHistoryHandler>().ShowActivityTooltipMessage(message);
    }
}