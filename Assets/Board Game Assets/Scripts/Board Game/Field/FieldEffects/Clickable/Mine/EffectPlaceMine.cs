using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlaceMine : FieldEffect
{
    public override void TriggerEffect()
    {
        print("Place a mine!");
        GenericTriggerEffect();
        CameraModesHandler cameraMovementHandler = InstanceManager.Instance.Get<CameraModesHandler>();
        cameraMovementHandler.SetCameraMode(cameraMovementHandler.freeLookMode);
        InstanceManager.Instance.Get<ClickEventHandler>().AddClickEvent(gameObject.AddComponent<MinePlacementClick>());
    }
}