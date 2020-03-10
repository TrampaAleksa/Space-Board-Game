using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModeFieldFollow : FollowCameraMode, ICameraMode
{
    private Transform target;

    public CameraModeFieldFollow(Transform camera) : base(camera)
    {
    }

    public void UpdateCamera()
    {
        target = InstanceManager.Instance.Get<FieldSelectionHandler>().GetSelectedField().transform;
        FollowTarget(target, offset, smoothSpeed);
    }
}