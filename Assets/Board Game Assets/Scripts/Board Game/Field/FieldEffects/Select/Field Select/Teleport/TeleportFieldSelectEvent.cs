using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportFieldSelectEvent
{
    public const int maximumDistanceAllowed = 3;

    public void ConfirmSelectedField(GameObject field)
    {
        GameObject playerToTeleport = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer();
        Field playersField = playerToTeleport.GetComponent<PlayerMovement>().currentPlayerField;
        Field selectedFieldComponent = field.GetComponent<Field>();
        if (InstanceManager.Instance.Get<FieldHandler>()
            .DistanceBetweenTwoFields(playersField, selectedFieldComponent) <= maximumDistanceAllowed)
        {
            InstanceManager.Instance.Get<PlayersHandler>()
             .GetCurrentPlayer()
             .GetComponent<PlayerMovement>()
             .currentPlayerField
             .GetComponent<SelectFieldEffect>()
             .FinishedSelecting();
            InstanceManager.Instance.Get<FieldSelectionHandler>().confirmedSelectionEvents -= ConfirmSelectedField;
            InstanceManager.Instance.Get<FieldHandler>().TeleportPlayerToField(playerToTeleport, selectedFieldComponent);
            playerToTeleport.GetComponent<PlayerMovement>().currentPlayerField.GetComponent<FieldEffect>().TriggerEffect();
            //teleport sound effect
        }
        else Debug.Log("Distance too large");
    }
}