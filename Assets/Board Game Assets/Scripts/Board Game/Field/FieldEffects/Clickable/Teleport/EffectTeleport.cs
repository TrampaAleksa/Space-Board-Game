using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTeleport : FieldEffect
{
    public override void TriggerEffect()
    {
        print("Emergency teleport!");
        GenericTriggerEffect();
        CameraModesHandler cameraMovementHandler = InstanceManager.Instance.Get<CameraModesHandler>();
        cameraMovementHandler.SetCameraMode(cameraMovementHandler.freeLookMode);
        InstanceManager.Instance.Get<ClickEventHandler>().AddClickEvent(gameObject.AddComponent<TeleportClick>());
    }
}