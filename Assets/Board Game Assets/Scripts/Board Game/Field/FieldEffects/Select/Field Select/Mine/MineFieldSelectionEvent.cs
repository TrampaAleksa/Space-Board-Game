using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineFieldSelectionEvent : MonoBehaviour, ISelectionEffect
{
    public void ConfirmedSelection()
    {
        GameObject selectedField = InstanceManager.Instance.Get<FieldSelectionHandler>().GetSelectedField();
        if (selectedField.GetComponent<EmptyField>() == null)
        {
            Debug.Log("Mine can only be placed on empty field");
            return;
        }

        selectedField.AddComponent<Mine>();

        new ATMinePlacement(
            InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer()
        ).DisplayAT();

        InstanceManager.Instance.Get<FieldEffectHandler>()
            .AddEffectToField(selectedField, selectedField.GetComponent<Mine>());
        InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(gameObject);
        //Mine placed sound
    }
}