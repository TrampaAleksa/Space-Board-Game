using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityHistoryHandler : GenericObjectArray
{
    private void Awake()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("ActivityTooltip");
    }

    public ActivityHistoryHandler ShowActivityTooltipMessage(string message)
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