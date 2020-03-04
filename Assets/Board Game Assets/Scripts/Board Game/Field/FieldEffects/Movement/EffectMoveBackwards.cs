using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMoveBackwards : FieldEffect
{
    public override void TooltipDisplay()
    {
        TooltipHandler tooltipHandler = InstanceManager.Instance.Get<TooltipHandler>();
        tooltipHandler.ShowFieldInfoTooltip("You moved backwards");
    }

    public override void TriggerEffect()
    {
        GenericTriggerEffect();
        GameObject currentPlayer = playersHandler.GetCurrentPlayer();
        InstanceManager.Instance.Get<MovementHandler>().MoveNFields(-1, currentPlayer);
    }
}