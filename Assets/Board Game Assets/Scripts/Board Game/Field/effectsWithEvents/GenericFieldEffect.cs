using System;
using UnityEngine;

public class GenericFieldEffect : MonoBehaviour, IFieldEffect
{
    public Action FinishedEffect()
    {
        throw new NotImplementedException();
    }

    public Action TriggerEffect()
    {
        throw new NotImplementedException();
    }
}