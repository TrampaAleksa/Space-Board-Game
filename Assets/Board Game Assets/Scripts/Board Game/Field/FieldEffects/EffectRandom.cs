using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EffectRandom : FieldEffect, IGenericFieldEffect
{
    public GameObject[] randomFieldEffects;
    public GameObject randomFieldPulled;

    private void Start()
    {
        randomFieldEffects = GameObject.FindGameObjectsWithTag("Random Field");
    }

    public override void TriggerEffect()
    {
        int index = Random.Range(0, randomFieldEffects.Length);
        print("Random effect: " + randomFieldEffects[index].name);
        randomFieldPulled = randomFieldEffects[index];
        InstanceManager.Instance.Get<FieldEffectHandler>().TriggerFieldEffects(randomFieldPulled);
    }

    public override void FinishedEffect()
    {
        InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(randomFieldPulled);
    }
}