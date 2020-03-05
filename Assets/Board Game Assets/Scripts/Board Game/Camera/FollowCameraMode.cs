using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraMode
{
    protected Transform camera;
    public float cameraRotationSpeed = 0.3f;

    public FollowCameraMode(Transform camera)
    {
        this.camera = Camera.main.transform;
    }
}