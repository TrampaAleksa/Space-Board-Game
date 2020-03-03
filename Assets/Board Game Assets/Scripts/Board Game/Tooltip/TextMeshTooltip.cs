using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextMeshTooltip : MonoBehaviour, ITooltipAction
{
    protected TextMeshPro tooltipTextComponent;
    protected Animator tooltipAnimator;
    public TooltipAnimationType defaultAnimationType;

    private void Start()
    {
        tooltipTextComponent = GetComponent<TextMeshPro>();
        tooltipAnimator = GetComponent<Animator>();
    }

    public void ShowTooltip(TooltipAnimationType type, string message)
    {
        tooltipTextComponent.text = message;
        tooltipAnimator.SetTrigger(type.ToString());
    }

    public void ShowTooltip(string message)
    {
        tooltipTextComponent.text = message;
        tooltipAnimator.SetTrigger(defaultAnimationType.ToString());
    }
}
