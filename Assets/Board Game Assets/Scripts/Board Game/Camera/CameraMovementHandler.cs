using UnityEngine;

public class CameraMovementHandler : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.305f;

    public Vector3 offset;
    public ICameraMode currentCameraMode;

    public ICameraMode freeLookMode;
    public ICameraMode playerFollowMode;
    public ICameraMode selectedFolllowMode;

    private void Start()
    {
        freeLookMode = new CameraModeMouseFollow();
        playerFollowMode = new CameraModePlayerFollow();
        selectedFolllowMode = new CameraModeSelectedFollow();
        currentCameraMode = freeLookMode;
    }

    private void LateUpdate()
    {
        currentCameraMode.UpdateCamera(offset, smoothSpeed);
    }

    public void SetCameraMode(ICameraMode mode)
    {
        currentCameraMode = mode;
    }

    public void DelayedFreeLookCameraModeSwitch(float time)
    {
        Invoke("DelayCameraModeSwitch", time);
    }

    private void DelayCameraModeSwitch()
    {
        CameraMovementHandler cameraMovementHandler = InstanceManager.Instance.Get<CameraMovementHandler>();
        cameraMovementHandler.SetCameraMode(cameraMovementHandler.freeLookMode);
    }
}