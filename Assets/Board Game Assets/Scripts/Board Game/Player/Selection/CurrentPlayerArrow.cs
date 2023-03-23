using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayerArrow : MonoBehaviour
{
    public Transform arrow;
    private PlayersHandler _playersHandler;
    public Vector3 offset;
    
    public AnimationCurve curve;
    
    public float speed = 1f;
    public float moveDistance = 0.2f;


    private void Start()
    {
        _playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {
            arrow.parent = _playersHandler.GetCurrentPlayer().transform;
            arrow.localPosition = Vector3.zero;
            arrow.position = _playersHandler.GetCurrentPlayer().transform.position + offset;
            
            LeanTween.cancel(arrow.gameObject);
            LeanTween.moveY(arrow.gameObject, arrow.position.y - moveDistance, speed).setEase(curve).setRepeat(-1);
        }
       // arrow.position = _playersHandler.GetCurrentPlayer().transform.position + offset;
    }
}
