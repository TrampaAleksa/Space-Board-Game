using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLockPlayer : FieldEffect
{
    public const int NUMBER_OF_TURNS = 1;

    public override void TriggerEffect()
    {
        GenericTriggerEffect();
        print("Your engines shut down!");
        InstanceManager.Instance.Get<TurnHandler>().AddPlayerTurnsToSkip(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer(), NUMBER_OF_TURNS);
        InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(gameObject);
    }

    public override void FinishedEffect()
    {
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}