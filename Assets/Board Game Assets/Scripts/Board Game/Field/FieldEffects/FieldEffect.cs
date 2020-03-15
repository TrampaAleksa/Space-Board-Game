using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FieldEffect : MonoBehaviour, IGenericFieldEffect
{
    [SerializeField]
    public PlayersHandler playersHandler;

    private void Start()
    {
    }

    public abstract void FinishedEffect();

    public abstract void TriggerEffect();

    public void GenericTriggerEffect()
    {
        playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
        DisplayFieldInfoTooltip();
    }

    private void DisplayFieldInfoTooltip()
    {
        TooltipHandler tooltipHandler = InstanceManager.Instance.Get<TooltipHandler>();

        tooltipHandler.ShowFieldInfoTooltip
            (InstanceManager.Instance.Get<FieldInfoDictionaryHandler>()
            .TooltipMessagesDictionary[gameObject.GetComponent<FieldEffect>().GetType()]);
    }
}