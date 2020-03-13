using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModesHandler : MonoBehaviour
{
    public Vector3 offset;

    private ICameraMode currentCameraMode;

    private Dictionary<Type, ICameraMode> cameraModesDictionary;

    private void Start()
    {
        cameraModesDictionary = new Dictionary<Type, ICameraMode>();
        Transform camera = Camera.main.transform;

        cameraModesDictionary.Add(typeof(CameraModeMouseFollow), new CameraModeMouseFollow());
        cameraModesDictionary.Add(typeof(CameraModePlayerFollow), new CameraModePlayerFollow(camera));
        cameraModesDictionary.Add(typeof(CameraModeSelectedFollow), new CameraModeSelectedFollow(camera));
        cameraModesDictionary.Add(typeof(CameraModeFieldFollow), new CameraModeFieldFollow(camera));
        currentCameraMode = cameraModesDictionary[typeof(CameraModePlayerFollow)];
    }

    private void LateUpdate()
    {
        currentCameraMode.UpdateCamera();
    }

    public void SetCameraMode<T>() where T : ICameraMode
    {
        StartCoroutine(DelayCameraSwitch(cameraModesDictionary[typeof(T)]));
    }

    private IEnumerator DelayCameraSwitch(ICameraMode cameraMode)
    {
        yield return new WaitForSeconds(1.5f);
        currentCameraMode = cameraMode;
    }
}