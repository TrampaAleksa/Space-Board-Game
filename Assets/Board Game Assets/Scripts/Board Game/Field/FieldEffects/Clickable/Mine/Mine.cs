using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : FieldEffect
{

    public override void TooltipDisplay()
    {
        TooltipHandler tooltipHandler = InstanceManager.Instance.Get<TooltipHandler>();
        tooltipHandler.ShowTooltip(tooltipHandler.fieldInfoTooltip, "Stepped on a mine!");
    }
    public override void TriggerEffect()
    {
        print("YOU STEPPED ON A MINE");
        Destroy(this);
    }
}
