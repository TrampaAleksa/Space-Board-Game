using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLockPlayer : FieldEffect
{
    public const int NUMBER_OF_TURNS = 1;
    public override void TriggerEffect()
    {
        print("Your engines shut down!");
        InstanceManager.Instance.Get<TurnHandler>().PlayerSkipTurns(playersHandler.GetCurrentPlayer(), NUMBER_OF_TURNS);
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}
