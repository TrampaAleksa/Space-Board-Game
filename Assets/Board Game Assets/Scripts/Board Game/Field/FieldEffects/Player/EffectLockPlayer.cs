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
        InstanceManager.Instance.Get<TurnHandler>().AddPlayerTurnsToSkip(playersHandler.GetCurrentPlayer(), NUMBER_OF_TURNS);
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }

    public override void FinishedEffect()
    {
        throw new System.NotImplementedException();
    }
}