using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityHistoryHandler : GenericObjectArray
{
    private readonly Queue<ActivityHistoryTooltip> _tooltips = new Queue<ActivityHistoryTooltip>();
    public Transform verticalLayout;
    
    private void Awake()
    {
        foreach (var tooltipObj in GameObject.FindGameObjectsWithTag("ActivityTooltip"))
            _tooltips.Enqueue(tooltipObj.GetComponent<ActivityHistoryTooltip>());
    }

    public ActivityHistoryHandler ShowActivityTooltipMessage(string message)
    {
        AddTooltipToBottomOfHistory(message);
        RefreshTooltipsLayout();
        return this;
    }

    
    private void AddTooltipToBottomOfHistory(string message)
    {
        var tooltipExitingHistory = _tooltips.Dequeue();
        _tooltips.Enqueue(tooltipExitingHistory); // move the tooltip from the bottom to the top

        tooltipExitingHistory.ClearActivityText().AddTextToTooltip(message);
    }

    private void RefreshTooltipsLayout()
    {
        foreach (var tooltip in _tooltips)
        {
            tooltip.transform.parent.transform.parent = null;
            tooltip.transform.parent.transform.parent = verticalLayout;
        }
    }
}