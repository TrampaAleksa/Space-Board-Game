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
        freeLookMode = new MouseFollow();
        playerFollowMode = new DefaultCameraMode();
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

    public class DefaultCameraMode : ICameraMode
    {
        private Transform target;
        private Transform camera;
        public float cameraRotationSpeed = 0.3f;

        public void UpdateCamera(Vector3 offset, float smoothSpeed)
        {
            target = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer().transform;
            camera = Camera.main.transform;
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(camera.position, desiredPosition, smoothSpeed * Time.deltaTime);
            camera.position = smoothedPosition;

            Vector3 _lookDirection = target.position - camera.position;
            Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
            camera.rotation = Quaternion.Lerp(camera.rotation, _rot, cameraRotationSpeed * Time.deltaTime);
        }
    }
}