using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class FieldEffect : MonoBehaviour, IGenericFieldEffect
{
    public abstract void FinishedEffect();

    public abstract void TriggerEffect();

}