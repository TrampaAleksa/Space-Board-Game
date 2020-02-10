using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FieldEffect : MonoBehaviour
{
    protected PlayersHandler playersHandler;

    private void Start()
    {
        playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
    }
    public abstract void TriggerEffect();
}
