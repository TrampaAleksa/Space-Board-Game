using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlaceMine : FieldEffect
{
    public override void TooltipDisplay()
    {
        TooltipHandler tooltipHandler = InstanceManager.Instance.Get<TooltipHandler>();
        tooltipHandler.ShowTooltip(tooltipHandler.fieldInfoTooltip, "Click on a field to place a mine");
    }

    public override void TriggerEffect()
    {
        print("Place a mine!");
        CameraMovementHandler cameraMovementHandler = InstanceManager.Instance.Get<CameraMovementHandler>();
        cameraMovementHandler.SetCameraMode(cameraMovementHandler.freeLookMode);
        InstanceManager.Instance.Get<ClickEventHandler>().AddClickEvent(gameObject.AddComponent<MinePlacementClick>());
    }
}
