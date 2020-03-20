using System;
using UnityEngine;

public class GenericFieldEffect : FieldEffect
{
    public override void FinishedEffect()
    {
        
    }

    public override void TriggerEffect()
    {
        DisplayFieldInfoTooltip();
    }
     private void DisplayFieldInfoTooltip()
    {
        TooltipHandler tooltipHandler = InstanceManager.Instance.Get<TooltipHandler>();

        tooltipHandler.ShowFieldInfoTooltip
            (InstanceManager.Instance.Get<FieldInfoDictionaryHandler>()
            .TooltipMessagesDictionary[gameObject.GetComponent<IGenericFieldEffect>().GetType()]);
    }
}