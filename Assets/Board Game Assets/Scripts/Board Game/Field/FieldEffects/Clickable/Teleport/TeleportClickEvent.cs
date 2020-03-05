using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportClickEvent : IFieldClickEvent
{
    public const int maximumDistanceAllowed = 3;

    public void FieldClickAction(IClickEvent clickComponent, GameObject hit)
    {
        Field fieldClicked = hit.GetComponentInChildren<Field>();
        if (hit.transform != null && fieldClicked != null)
        {
            GameObject playerToTeleport = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer();
            Field playersField = playerToTeleport.GetComponent<PlayerMovement>().currentPlayerField;
            if (InstanceManager.Instance.Get<FieldHandler>()
                .DistanceBetweenTwoFields(playersField, fieldClicked) <= maximumDistanceAllowed)
            {
                InstanceManager.Instance.Get<FieldHandler>().TeleportPlayerToField(playerToTeleport, fieldClicked);
                InstanceManager.Instance.Get<ClickEventHandler>().RemoveClickEvent(clickComponent);
                playerToTeleport.GetComponent<PlayerMovement>().currentPlayerField.GetComponent<FieldEffect>().TriggerEffect();
                MonoBehaviour.Destroy((TeleportClick)clickComponent);
                //teleport sound effect
            }
            else Debug.Log("Distance too large");
        }
    }
}