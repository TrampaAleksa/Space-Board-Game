using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportClick : MonoBehaviour, IClickEvent
{
    public const int maximumDistanceAllowed = 3;

    public IClickEvent Clicked()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Field")))
        {
            Field fieldClicked = hit.collider.gameObject.GetComponentInChildren<Field>();
            if (hit.transform != null && fieldClicked != null)
            {
                GameObject playerToTeleport = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer();
                Field playersField = playerToTeleport.GetComponent<PlayerMovement>().currentPlayerField;
                if (InstanceManager.Instance.Get<FieldHandler>().DistanceBetweenTwoFields(playersField, fieldClicked) <= maximumDistanceAllowed)
                {
                    InstanceManager.Instance.Get<FieldHandler>().TeleportPlayerToField(playerToTeleport, fieldClicked);
                    InstanceManager.Instance.Get<ClickEventHandler>().RemoveClickEvent(this);
                    playerToTeleport.GetComponent<PlayerMovement>().currentPlayerField.GetComponent<FieldEffect>().TriggerEffect();
                    Destroy(this);
                    //teleport sound effect
                }
                else print("Distance too large");
            }
        }
        return this;
    }
}