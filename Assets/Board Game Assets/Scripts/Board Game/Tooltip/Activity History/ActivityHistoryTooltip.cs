using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityHistoryTooltip : MonoBehaviour
{
    private Text tooltipText;

    private void Start()
    {
        tooltipText = GetComponent<Text>();
    }

    public ActivityHistoryTooltip AddTextToTooltip(string textToAdd)
    {
        tooltipText.text += textToAdd;
        return this;
    }

    public ActivityHistoryTooltip AddTextToTooltip(string textToAdd, string tag)
    {
        //TODO -- write a util class for handling tags properly, with checks for invalid tags etc.
        //TODO -- Use string builder perhaps?
        tooltipText.text += "<" + tag + ">" + textToAdd + "</" + tag + ">";
        return this;
    }

    public ActivityHistoryTooltip ClearActivityText()
    {
        tooltipText.text = " ";
        return this;
    }
}