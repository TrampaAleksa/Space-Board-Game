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

    private Dictionary<string, string> tooltipMessagesDictionary;

    private void Awake()
    {
        tooltipMessagesDictionary = new Dictionary<string, string>();
        AddMessagesToDictionary(tooltipMessagesDictionary);
    }

    private void AddMessagesToDictionary(Dictionary<string, string> tooltipMessagesDictionary)
    {
        throw new NotImplementedException();
    }

    private void Start()
    {
        playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
    }

    public abstract void TriggerEffect();

    public abstract void TooltipDisplay();

    public void GenericTriggerEffect()
    {
        DisplayFieldInfoTooltip();
    }

    private void DisplayFieldInfoTooltip()
    {
        TooltipHandler tooltipHandler = InstanceManager.Instance.Get<TooltipHandler>();
        tooltipHandler.ShowFieldInfoTooltip("Generic message");
    }
}