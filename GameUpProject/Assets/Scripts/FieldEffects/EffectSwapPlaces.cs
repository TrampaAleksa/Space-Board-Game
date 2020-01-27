using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSwapPlaces : FieldEffect
{
    public override void TriggerEffect()
    {
        playersHandler.EndCurrentPlayersTurn();
        print("end turn");
    }

}
