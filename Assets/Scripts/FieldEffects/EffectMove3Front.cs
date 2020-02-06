using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMove3Front : FieldEffect
{
    public override void TriggerEffect()
    {
        GameObject currentPlayer = playersHandler.GetCurrentPlayer();
        InstanceManager.Instance.Get<PlayerFieldMovement>().MoveNFields(2, currentPlayer);
    }

}
