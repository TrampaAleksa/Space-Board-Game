using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionIndicatorHandler : MonoBehaviour
{
    // positioning
    public Transform arrow;
    private PlayersHandler _playersHandler;
    public Vector3 offset;
    
    // tween parameters
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
            var currentPlayer = _playersHandler.GetCurrentPlayer().transform;
            SetArrow(currentPlayer);
        }
    }

    
    //Selection indication gets set when its a players turn, a field gets selected, and a player gets selected
    public void SetArrow(Transform target)
    {
        arrow.parent = target;
        arrow.localPosition = Vector3.zero;
        arrow.position = target.position + offset;
            
        LeanTween.cancel(arrow.gameObject);
        LeanTween.moveY(arrow.gameObject, arrow.position.y - moveDistance, speed).setEase(curve).setRepeat(-1);
    }
}
