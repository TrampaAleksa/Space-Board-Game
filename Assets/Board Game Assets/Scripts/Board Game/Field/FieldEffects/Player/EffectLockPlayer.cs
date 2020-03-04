using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLockPlayer : FieldEffect
{
    public const int NUMBER_OF_TURNS = 1;

    public override void TooltipDisplay()
    {
        TooltipHandler tooltipHandler = InstanceManager.Instance.Get<TooltipHandler>();
        tooltipHandler.ShowFieldInfoTooltip("Engines shut down!");
    }

    public override void TriggerEffect()
    {
        GenericTriggerEffect();
        print("Your engines shut down!");
        InstanceManager.Instance.Get<TurnHandler>().AddPlayerTurnsToSkip(playersHandler.GetCurrentPlayer(), NUMBER_OF_TURNS);
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}