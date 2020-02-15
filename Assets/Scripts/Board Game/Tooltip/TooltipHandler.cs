using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipHandler : MonoBehaviour
{
    public const float TOOLTIP_TIME_SHORT = 2f;
    public const float TOOLTIP_TIME_NORMAL = 5f;
    public const float TOOLTIP_TIME_LONG = 10f;

    private void Awake()
    {
        GameObject[] tooltipObjs = GameObject.FindGameObjectsWithTag("Tooltip");
        foreach(var tooltip in tooltipObjs)
        {
            if(tooltip.GetComponent<Tooltip>() == null)
            tooltip.AddComponent<Tooltip>();
        }
    }

    public void ShowTooltipForGivenTime(Tooltip tooltipToShow, string message, float timeToShow)
    {
        tooltipToShow.ShowTooltip(message);
        StartCoroutine(RemoveTooltipWithDelay(tooltipToShow, timeToShow));
    }

    private IEnumerator RemoveTooltipWithDelay(Tooltip tooltipToRemove, float delay)
    {
        yield return new WaitForSeconds(delay);
        tooltipToRemove.RemoveTooltip();
    }

    /// <summary>
    /// If you sometimes need to get the reference to a specific tooltip, use this method
    /// </summary>
    /// <param name="name">The name of the gameobject the tooltip is attached to</param>
    /// <returns>The tooltip component from the game object found</returns>
    public Tooltip FindTooltipByGameObjectName(string name)
    {
        Tooltip tooltipFound = GameObject.Find(name).GetComponent<Tooltip>();
        if (tooltipFound == null) {
            Debug.Log("Error, tooltip was not found, wrong name or no component attached");
        }
        return tooltipFound;
    }

}
