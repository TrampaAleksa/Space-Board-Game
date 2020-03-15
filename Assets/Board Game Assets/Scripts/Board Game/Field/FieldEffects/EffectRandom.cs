using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRandom : FieldEffect
{
    private FieldEffect effectToTrigger;

    private void Start()
    {
        effectsList = GameObject.Find("Random Effects Holder").GetComponentsInChildren<FieldEffect>();
    }

    public FieldEffect[] effectsList;

    public override void TriggerEffect()
    {
        GenericTriggerEffect();
        int index = Random.Range(0, effectsList.Length);
        print("Random effect: " + effectsList[index].name);
        effectToTrigger = gameObject.AddComponent(effectsList[index].GetType()) as FieldEffect;

        InstanceManager.Instance.Get<FieldEffectHandler>().AddEffectToField(gameObject, effectToTrigger);
        InstanceManager.Instance.Get<FieldEffectHandler>().AddEffectFinishedEventToField(gameObject, effectToTrigger);
        InstanceManager.Instance.Get<FieldEffectHandler>().RemoveEffectFromField(gameObject, GetComponent<EffectRandom>());
        InstanceManager.Instance.Get<FieldEffectHandler>().TriggerFieldEffects(gameObject);
    }

    public override void FinishedEffect()
    {
        InstanceManager.Instance.Get<FieldEffectHandler>().RemoveEffectFinishedEventFromField(gameObject, effectToTrigger);
        InstanceManager.Instance.Get<FieldEffectHandler>().RemoveEffectFromField(gameObject, effectToTrigger);
        Destroy(effectToTrigger);
        InstanceManager.Instance.Get<FieldEffectHandler>().AddEffectToField(gameObject, GetComponent<EffectRandom>());
    }
}