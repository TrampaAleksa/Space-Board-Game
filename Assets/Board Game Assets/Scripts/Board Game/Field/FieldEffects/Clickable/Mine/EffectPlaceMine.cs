using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlaceMine : FieldEffect
{
    public override void TriggerEffect()
    {
        print("Place a mine!");
        GenericTriggerEffect();
        CameraMovementHandler cameraMovementHandler = InstanceManager.Instance.Get<CameraMovementHandler>();
        cameraMovementHandler.SetCameraMode(cameraMovementHandler.freeLookMode);
        InstanceManager.Instance.Get<ClickEventHandler>().AddClickEvent(gameObject.AddComponent<MinePlacementClick>());
    }
}