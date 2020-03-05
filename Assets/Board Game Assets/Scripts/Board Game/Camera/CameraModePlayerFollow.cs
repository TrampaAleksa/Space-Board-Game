using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModePlayerFollow : FollowCameraMode, ICameraMode
{
    private Transform target;

    public CameraModePlayerFollow(Transform camera) : base(camera)
    {
    }

    public void UpdateCamera(Vector3 offset, float smoothSpeed)
    {
        target = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer().transform;
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(camera.position, desiredPosition, smoothSpeed * Time.deltaTime);
        camera.position = smoothedPosition;

        Vector3 _lookDirection = target.position - camera.position;
        Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
        camera.rotation = Quaternion.Lerp(camera.rotation, _rot, cameraRotationSpeed * Time.deltaTime);
    }
}