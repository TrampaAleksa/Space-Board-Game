using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayerArrow : MonoBehaviour
{
    public Transform arrow;
    private PlayersHandler _playersHandler;
    public Vector3 offset;


    private void Start()
    {
        _playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
    }

    private void Update()
    {
        arrow.position = _playersHandler.GetCurrentPlayer().transform.position + offset;
    }
}
