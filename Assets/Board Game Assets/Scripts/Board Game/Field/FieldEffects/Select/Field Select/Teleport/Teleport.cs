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
            InstanceManager.Instance.Get<FieldHandler>()
                .TeleportPlayerToField(references.playerToTeleport, references.selectedFieldComponent);
            DisplayInActivityHistory();
            InstanceManager.Instance.Get<FieldEffectHandler>()
                .TriggerEffectFinishedEvents(references.playersField.gameObject);
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
        InstanceManager.Instance.Get<FieldEffectHandler>().TriggerFieldEffects(fieldTeleportedTo.gameObject);
    }
    
    private static void DisplayInActivityHistory()
    {
        string message = new ATTeleported(
            InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer()
        ).BuildActivityTooltip();
        InstanceManager.Instance.Get<ActivityHistoryHandler>().ShowActivityTooltipMessage(message);
    }
}