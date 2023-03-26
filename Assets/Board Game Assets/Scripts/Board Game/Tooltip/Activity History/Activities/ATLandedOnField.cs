using UnityEngine;

public class ATLandedOnField : ActivityTooltipBuilder
{
    public string fieldType = "empty";
    public ATLandedOnField(GameObject player) :base(player)
    {
        BuildActivityTooltip();
    }
    
    public sealed override void BuildActivityTooltip()
    {
        tooltipMessage += player1Name;
        tooltipMessage += " landed on '";
        tooltipMessage += fieldType;
        tooltipMessage += "' field";
    }
}