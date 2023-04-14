using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityHistoryHandler : GenericObjectArray
{

    public Queue<ActivityHistoryTooltip> tooltips = new Queue<ActivityHistoryTooltip>();
    public Transform verticalLayout;
    
    private void Awake()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("ActivityTooltip");
        foreach (var tooltipObj in gameObjects)
            tooltips.Enqueue(tooltipObj.GetComponent<ActivityHistoryTooltip>());
        
    }

    public ActivityHistoryHandler ShowActivityTooltipMessage(string message)
    {
        return HandleWithQueueImpl(message);
        //return HandleWithGenericArrayImpl(message);
    }

    private ActivityHistoryHandler HandleWithQueueImpl(string message)
    {
        AddTooltipToBottomOfHistory(message);
        RefreshTooltipsLayout();
        return this;
    }

    private void AddTooltipToBottomOfHistory(string message)
    {
        var tooltipExitingHistory = tooltips.Dequeue();
        tooltips.Enqueue(tooltipExitingHistory); // move the tooltip from the bottom to the top

        tooltipExitingHistory.ClearActivityText().AddTextToTooltip(message);
    }

    private void RefreshTooltipsLayout()
    {
        foreach (var tooltip in tooltips)
        {
            tooltip.transform.parent.transform.parent = null;
            tooltip.transform.parent.transform.parent = verticalLayout;
        }
    }

    private ActivityHistoryHandler HandleWithGenericArrayImpl(string message)
    {
        for (int i=0; i< ArrayLength()-1 ; i++){
            TooltipWithIndex(i).ClearActivityText()
                .AddTextToTooltip(TooltipWithIndex(i+1).TooltipText.text);
        }
        ActivityHistoryTooltip lastAHTooltip = LastMember().GetComponent<ActivityHistoryTooltip>();
        lastAHTooltip.ClearActivityText().AddTextToTooltip(message);
        return this;
    }

    private ActivityHistoryTooltip TooltipWithIndex(int i){
        return MemberWithIndex(i).GetComponent<ActivityHistoryTooltip>();
    }
}