using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : FieldEffect
{
    public override void TriggerEffect()
    {
        print("YOU STEPPED ON A MINE");
        Destroy(this);
    }
}