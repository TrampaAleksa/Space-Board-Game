using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FieldEffect : MonoBehaviour
{
    public FieldPath path;
    public PlayersHandler playersHandler;

    private void Start()
    {
        path = GameObject.Find("Field Container").GetComponent<FieldPath>();
        playersHandler = GameObject.Find("PlayerManager").GetComponent<PlayersHandler>();
    }
    public abstract void TriggerEffect();
}
