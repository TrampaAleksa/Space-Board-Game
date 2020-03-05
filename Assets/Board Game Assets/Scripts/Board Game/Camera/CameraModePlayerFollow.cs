using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModePlayerFollow : FollowCameraMode, ICameraMode
{
    private Transform target;

    public CameraModePlayerFollow(Transform camera) : base(camera)
    {
    }

    public void UpdateCamera()
    {
        target = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer().transform;
        FollowTarget(target, offset, smoothSpeed);
    }
}