using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModeSelectedFollow : FollowCameraMode, ICameraMode
{
    private Transform target;

    public CameraModeSelectedFollow(Transform camera) : base(camera)
    {
    }

    public void UpdateCamera()
    {
        target = InstanceManager.Instance.Get<SelectionHandler>().GetSelectedPlayer().transform;
        FollowTarget(target, offset, smoothSpeed);
    }
}