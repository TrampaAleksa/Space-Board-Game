using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyField : FieldEffect
{
    public override void TriggerEffect()
    {
        playersHandler.EndCurrentPlayersTurn();
        print("No effect!");
    }
}
