using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FieldEffect : MonoBehaviour, IGenericFieldEffect
{
    [SerializeField]

    public abstract void FinishedEffect();

    public abstract void TriggerEffect();

}