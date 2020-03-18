using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityHistoryTooltip : MonoBehaviour
{
    private Text tooltipText;

    public Text TooltipText { get => tooltipText; set => tooltipText = value; }

    private void Start()
    {
        TooltipText = GetComponent<Text>();
        tooltipText.text = "";
    }

    public ActivityHistoryTooltip AddTextToTooltip(string textToAdd)
    {
        TooltipText.text += textToAdd;
        return this;
    }

    public ActivityHistoryTooltip ClearActivityText()
    {
        TooltipText.text = "";
        return this;
    }
}