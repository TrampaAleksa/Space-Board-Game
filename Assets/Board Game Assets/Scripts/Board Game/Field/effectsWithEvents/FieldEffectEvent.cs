using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldEffectEvent : MonoBehaviour
{
    public event Action triggerFieldEvents;

    public event Action finishedEffectEvents;

    public void TriggerFieldEvent()
    {
        triggerFieldEvents.Invoke();
    }

    public void TriggerFinishedEffectEvents()
    {
        finishedEffectEvents.Invoke();
    }
}