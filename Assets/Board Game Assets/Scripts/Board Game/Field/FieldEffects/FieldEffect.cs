using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FieldEffect : MonoBehaviour, IGenericFieldEffect
{
    [SerializeField]
    public PlayersHandler playersHandler;

    public const string TAG_SELECTION = "Selection";
    protected ISelectionEffect selectionEffect;

    private void Start()
    {
        playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
    }

    public abstract void TriggerEffect();

    public void GenericTriggerEffect()
    {
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