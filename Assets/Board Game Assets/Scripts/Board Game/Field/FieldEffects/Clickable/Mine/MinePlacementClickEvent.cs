using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinePlacementClickEvent : IFieldClickEvent
{
    public void FieldClickAction(IClickEvent mineClickEvent, GameObject hit)
    {
        if (hit.transform != null && hit.GetComponentInChildren<Field>() != null)
        {
            if (hit.GetComponent<Mine>() == null)
            {
                hit.AddComponent<Mine>();
                InstanceManager.Instance.Get<ClickEventHandler>().RemoveClickEvent(mineClickEvent);
                InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
                MonoBehaviour.Destroy((MinePlacementClick)mineClickEvent);
                //Mine placed sound
            }
            else Debug.Log("mine already exists");
        }
    }
}