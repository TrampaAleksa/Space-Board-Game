using UnityEngine;

public class CameraModesHandler : MonoBehaviour
{
    public Vector3 offset;

    public ICameraMode currentCameraMode;

    public ICameraMode freeLookMode;
    public ICameraMode playerFollowMode;
    public ICameraMode selectedFolllowMode;
    public ICameraMode fieldFollowMode;

    private void Start()
    {
        Transform camera = Camera.main.transform;
        freeLookMode = new CameraModeMouseFollow();
        playerFollowMode = new CameraModePlayerFollow(camera);
        selectedFolllowMode = new CameraModeSelectedFollow(camera);
        fieldFollowMode = new CameraModeFieldFollow(camera);
        currentCameraMode = playerFollowMode;
    }

    private void LateUpdate()
    {
        currentCameraMode.UpdateCamera();
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
        CameraModesHandler cameraMovementHandler = InstanceManager.Instance.Get<CameraModesHandler>();
        cameraMovementHandler.SetCameraMode(cameraMovementHandler.freeLookMode);
    }
}