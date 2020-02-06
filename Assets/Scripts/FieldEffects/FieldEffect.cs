using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FieldEffect : MonoBehaviour
{
    private FieldPath path;
    protected PlayersHandler playersHandler;


    private void Start()
    {
        path = InstanceManager.Instance.Get<FieldPath>();
        playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
    }
    public abstract void TriggerEffect();
}
