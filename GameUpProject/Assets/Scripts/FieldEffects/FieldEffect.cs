using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FieldEffect : MonoBehaviour
{
    public FieldPath path;

    private void Start()
    {
        path = GameObject.Find("Field Container").GetComponent<FieldPath>();
    }
    public abstract void TriggerEffect();
}
