using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMove3Front : FieldEffect
{
    public override void TriggerEffect()
    {
       // playersHandler.players[playersHandler.currentPlayerIndex].GetComponent<PlayerMovement>().MoveNFields(2);
        print("Move 3 spaces in front");
    }

}
