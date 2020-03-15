using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldEffectHandler : MonoBehaviour
{
    public FieldEffectHandler AddEffectToField(GameObject field, IFieldEffect effectToAdd)
    {
        field.GetComponent<FieldEffectEvent>().triggerFieldEvents += effectToAdd.TriggerEffect();
        return this;
    }

    public FieldEffectHandler RemoveEffectFromField(GameObject field, IFieldEffect effectToAdd)
    {
        field.GetComponent<FieldEffectEvent>().triggerFieldEvents -= effectToAdd.TriggerEffect();
        return this;
    }

    public FieldEffectHandler AddEffectFinishedEventToField(GameObject field, IFieldEffect effectToAdd)
    {
        field.GetComponent<FieldEffectEvent>().triggerFieldEvents += effectToAdd.FinishedEffect();
        return this;
    }

    public FieldEffectHandler RemoveEffectFinishedEventFromField(GameObject field, IFieldEffect effectToAdd)
    {
        field.GetComponent<FieldEffectEvent>().triggerFieldEvents -= effectToAdd.FinishedEffect();
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