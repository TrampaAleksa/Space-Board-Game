using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldEffectHandler : MonoBehaviour
{
    public FieldEffectHandler AddEffectToField(GameObject field, FieldEffect effectToAdd)
    {
        field.GetComponent<FieldEffectEvent>().triggerFieldEvents += effectToAdd.TriggerEffect;
        print("added" + field.name + " fields effect to action");
        return this;
    }

    public FieldEffectHandler RemoveEffectFromField(GameObject field, FieldEffect effectToRemove)
    {
        field.GetComponent<FieldEffectEvent>().triggerFieldEvents -= effectToRemove.TriggerEffect;
        return this;
    }

    public FieldEffectHandler AddEffectFinishedEventToField(GameObject field, FieldEffect effectToAdd)
    {
        field.GetComponent<FieldEffectEvent>().finishedEffectEvents += effectToAdd.FinishedEffect;
        return this;
    }

    public FieldEffectHandler RemoveEffectFinishedEventFromField(GameObject field, FieldEffect effectToRemove)
    {
        field.GetComponent<FieldEffectEvent>().finishedEffectEvents -= effectToRemove.FinishedEffect;
        return this;
    }

    public FieldEffectHandler TriggerFieldEffects(GameObject field)
    {
        field.GetComponent<FieldEffectEvent>().TriggerFieldEvent();
        return this;
    }

    public FieldEffectHandler TriggerEffectFinishedEvents(GameObject field)
    {
        field.GetComponent<FieldEffectEvent>().TriggerFinishedEffectEvents();
        return this;
    }
}