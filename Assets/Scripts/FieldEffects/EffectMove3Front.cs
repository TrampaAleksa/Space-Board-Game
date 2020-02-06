using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMove3Front : FieldEffect
{
    public override void TriggerEffect()
    {
        GameObject currentPlayer = playersHandler.players[playersHandler.currentPlayerIndex];
        InstanceManager.Instance.Get<MovementHandler>().MoveNFields(2, currentPlayer);
    }

}
