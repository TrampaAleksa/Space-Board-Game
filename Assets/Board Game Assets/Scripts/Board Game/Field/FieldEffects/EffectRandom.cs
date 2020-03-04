using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRandom : FieldEffect
{
    public override void TooltipDisplay()
    {
        TooltipHandler tooltipHandler = InstanceManager.Instance.Get<TooltipHandler>();
        tooltipHandler.ShowFieldInfoTooltip("Random effect occured!");
    }

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
        effectsList[index].TriggerEffect();
    }
}