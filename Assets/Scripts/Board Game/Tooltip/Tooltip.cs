using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Tooltip : MonoBehaviour
{
    private Text tooltipTextComponent;

    private void Start()
    {
        tooltipTextComponent = GetComponent<Text>();
    }

    //If you want some customizability for the tooltips, just implement these methods differently
    internal void ShowTooltip(string message)
    {
        tooltipTextComponent.text = message;
        tooltipTextComponent.gameObject.transform.localScale = Vector3.one;
    }

    internal void RemoveTooltip()
    {
        tooltipTextComponent.gameObject.transform.localScale = Vector3.zero;
    }
}