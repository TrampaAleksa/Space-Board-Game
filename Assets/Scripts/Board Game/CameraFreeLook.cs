using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFreeLook : ICameraMode
{
    private Vector3 target;
    private Camera camera;
    private float cameraMovementSpeed = 30f;


    public void UpdateCamera(Vector3 offset, float smoothSpeed)
    {
        camera = Camera.main;

    }
}
