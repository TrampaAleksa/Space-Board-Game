using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportFieldSelectionEffect : ISelectionEffect
{
    public const int maximumDistanceAllowed = 3;

    private GameObject fieldOfPlayerSelecting;

    public TeleportFieldSelectionEffect(GameObject fieldOfPlayerSelecting)
    {
        this.fieldOfPlayerSelecting = fieldOfPlayerSelecting;
    }

    public void ConfirmedSelection()
    {
        FieldSelectionHandler fieldSelectionHandler = InstanceManager.Instance.Get<FieldSelectionHandler>();
        GameObject playerToTeleport = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer();
        Field playersField = playerToTeleport.GetComponent<PlayerMovement>().currentPlayerField;
        Field selectedFieldComponent = fieldSelectionHandler.CurrentMember().GetComponent<Field>();

        if (InstanceManager.Instance.Get<FieldHandler>()
            .DistanceBetweenTwoFields(playersField, selectedFieldComponent) <= maximumDistanceAllowed)
        {
            fieldOfPlayerSelecting.GetComponent<SelectEffect>().FinishedSelecting();

            InstanceManager.Instance.Get<FieldHandler>().TeleportPlayerToField(playerToTeleport, selectedFieldComponent);
            playerToTeleport.GetComponent<PlayerMovement>().currentPlayerField.GetComponent<FieldEffect>().TriggerEffect();
            //teleport sound effect
        }
        else Debug.Log("Distance too large");
    }
}