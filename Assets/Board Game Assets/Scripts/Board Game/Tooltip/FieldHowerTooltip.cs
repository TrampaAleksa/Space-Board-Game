using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FieldHowerTooltip : MonoBehaviour, ITooltipAction
{
    protected TextMeshPro tooltipTextComponent;
    protected Animator tooltipAnimator;
    public TooltipAnimationType defaultAnimationType;

    private void Start()
    {
        tooltipTextComponent = GetComponentInChildren<TextMeshPro>();
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
        tooltipAnimator.SetBool("HoveredOver", true);
    }

    public void RemoveTooltip()
    {
        tooltipAnimator.SetBool("HoveredOver", false);
    }
}