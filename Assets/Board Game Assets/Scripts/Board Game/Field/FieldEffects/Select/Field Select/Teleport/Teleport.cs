using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Teleport
{
    public const int maximumDistanceAllowed = 3;

    public static void TryTeleporting(PlayerAndFieldReferences references)
    {
        if (SelectedFieldIsInDistance(references))
        {
            references.playersField.GetComponent<SelectEffect>()
                .FinishedSelecting();

            InstanceManager.Instance.Get<FieldHandler>()
                .TeleportPlayerToField(references.playerToTeleport, references.selectedFieldComponent);

            TriggerFieldsEffect(references.selectedFieldComponent);
            //teleport sound effect
        }
        else InstanceManager.Instance.Get<TooltipHandler>().ShowInfoTooltip("Distance too Large");
    }

    private static bool SelectedFieldIsInDistance(PlayerAndFieldReferences references)
    {
        return InstanceManager.Instance.Get<FieldHandler>()
                       .DistanceBetweenTwoFields(references.playersField, references.selectedFieldComponent)
                       <= maximumDistanceAllowed;
    }

    private static void TriggerFieldsEffect(Field fieldTeleportedTo)
    {
        fieldTeleportedTo.gameObject.GetComponent<FieldEffect>().TriggerEffect();
    }
}