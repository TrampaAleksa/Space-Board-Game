using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraMode
{
    protected Transform camera;
    public float cameraRotationSpeed = 0.3f;

    public float smoothSpeed = 0.3f;
    public Vector3 offset;

    public FollowCameraMode(Transform camera)
    {
        offset = InstanceManager.Instance.Get<CameraModesHandler>().offset;
        this.camera = Camera.main.transform;
    }

    public void FollowTarget(Transform target, Vector3 offset, float smoothSpeed)
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(camera.position, desiredPosition, smoothSpeed * Time.deltaTime);
        camera.position = smoothedPosition;

        Vector3 _lookDirection = target.position - camera.position;
        Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
        camera.rotation = Quaternion.Lerp(camera.rotation, _rot, cameraRotationSpeed * Time.deltaTime);
    }
}