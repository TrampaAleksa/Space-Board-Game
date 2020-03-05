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
        Lerping.LerpObjectToPosition(target.position + offset, camera.gameObject, smoothSpeed);

        Lerping.LerpObjectRotationToPosition(target.position, camera.gameObject, cameraRotationSpeed);
    }
}