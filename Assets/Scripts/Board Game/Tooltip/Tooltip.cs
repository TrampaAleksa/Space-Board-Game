using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Tooltip : MonoBehaviour
{
    protected Text tooltipTextComponent;
    protected Animator tooltipAnimator;
    public TooltipAnimationType defaultAnimationType;

    private void Start()
    {
        tooltipTextComponent = GetComponent<Text>();
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