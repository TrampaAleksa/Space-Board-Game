using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLockPlayer : FieldEffect, IGenericFieldEffect
{
    public static int numberOfTurns => GameConfig.GetConfig<EnginesConfig>().turnsToBreakPlayerEngine;

    public override void TriggerEffect()
    {
        InstanceManager.Instance.Get<TurnHandler>().AddPlayerTurnsToSkip(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer(), numberOfTurns);
        InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(gameObject);
    }

    public override void FinishedEffect()
    {
        DisplayInActivityHistory();
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }

    private void DisplayInActivityHistory()
    {
        new ATPlayerLocked(
            InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer(),
            numberOfTurns
        ).DisplayAT();
    }
}