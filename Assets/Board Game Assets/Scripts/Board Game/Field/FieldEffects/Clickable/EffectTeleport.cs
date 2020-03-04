using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTeleport : FieldEffect
{
    public override void TooltipDisplay()
    {
        TooltipHandler tooltipHandler = InstanceManager.Instance.Get<TooltipHandler>();
        tooltipHandler.ShowFieldInfoTooltip("Click on a field to teleport to");
    }

    public override void TriggerEffect()
    {
        print("Emergency teleport!");
        GenericTriggerEffect();
        CameraMovementHandler cameraMovementHandler = InstanceManager.Instance.Get<CameraMovementHandler>();
        cameraMovementHandler.SetCameraMode(cameraMovementHandler.freeLookMode);
        InstanceManager.Instance.Get<ClickEventHandler>().AddClickEvent(gameObject.AddComponent<TeleportClick>());
    }
}