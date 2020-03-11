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
        TryTeleporting(new PlayerAndFieldReferences());
    }

    public void TryTeleporting(PlayerAndFieldReferences references)
    {
        if (SelectedFieldIsInDistance(references))
        {
            fieldOfPlayerSelecting.GetComponent<SelectEffect>().FinishedSelecting();

            InstanceManager.Instance.Get<FieldHandler>()
                .TeleportPlayerToField(references.playerToTeleport, references.selectedFieldComponent);

            TriggerFieldsEffect(references.selectedFieldComponent);
            //teleport sound effect
        }
        else InstanceManager.Instance.Get<TooltipHandler>().ShowInfoTooltip("Distance too Large");
    }

    private static void TriggerFieldsEffect(Field fieldTeleportedTo)
    {
        fieldTeleportedTo.gameObject.GetComponent<FieldEffect>().TriggerEffect();
    }

    private static bool SelectedFieldIsInDistance(PlayerAndFieldReferences references)
    {
        return InstanceManager.Instance.Get<FieldHandler>()
                       .DistanceBetweenTwoFields(references.playersField, references.selectedFieldComponent) <= maximumDistanceAllowed;
    }
}

public class PlayerAndFieldReferences
{
    public GameObject playerToTeleport;
    public Field playersField;
    public Field selectedFieldComponent;

    public PlayerAndFieldReferences()
    {
        playerToTeleport = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer();
        playersField = playerToTeleport.GetComponent<PlayerMovement>().currentPlayerField;
        selectedFieldComponent = InstanceManager.Instance.Get<FieldSelectionHandler>().GetCurrentField();
    }
}