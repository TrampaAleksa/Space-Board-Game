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
        ActivityHistoryTooltip currentAHTooltip = CurrentMember().GetComponent<ActivityHistoryTooltip>();
        currentAHTooltip.ClearActivityText().AddTextToTooltip(message);
        SetToNextMember();
        return this;
    }
}