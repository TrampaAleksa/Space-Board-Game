using UnityEngine;

public class ATLandedOnField : ActivityTooltipBuilder
{
    private string _fieldType = "empty";
    public ATLandedOnField(GameObject player) :base(player)
    { }
    
    public sealed override void BuildActivityTooltip()
    {
        tooltipMessage += player1Name;
        tooltipMessage += " landed on ";
        tooltipMessage += GetSuffix(_fieldType);
        tooltipMessage += " '";
        tooltipMessage += _fieldType;
        tooltipMessage += "' field";
    }

    public ATLandedOnField SetFieldType(string type)
    {
        _fieldType = type;
        BuildActivityTooltip();
        return this;
    }

    private string GetSuffix(string fieldType)
    {
        if (fieldType.StartsWith("A") ||  fieldType.StartsWith("E") ||  fieldType.StartsWith("I") ||  fieldType.StartsWith("O") ||  fieldType.StartsWith("U"))
            return "an";

        return "a";
    }
}