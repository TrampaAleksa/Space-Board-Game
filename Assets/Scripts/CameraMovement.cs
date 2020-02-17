using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.305f;
    public Vector3 offset;

    public ICameraMode currentCameraMode;

    private void Start()
    {
        //currentCameraMode = new CameraFreeLook();
        currentCameraMode = new DefaultCameraMode();
    }
    private void LateUpdate()
    {
        currentCameraMode.UpdateCamera(offset, smoothSpeed);
    }

    public void SetCameraMode(ICameraMode mode)
    {
        currentCameraMode = mode;
    }

    public class DefaultCameraMode : ICameraMode
    {
        Transform target;
        Transform camera;
        public void UpdateCamera(Vector3 offset, float smoothSpeed)
        {
            target = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer().transform;
            camera = Camera.main.transform;
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(camera.position, desiredPosition, smoothSpeed * Time.deltaTime);
            camera.position = smoothedPosition;
        }
    }
}
