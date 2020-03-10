using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTeleport : FieldEffect
{
    public override void TriggerEffect()
    {
        print("Emergency teleport!");
        GenericTriggerEffect();
        gameObject.tag = TAG_SELECTION;

        FieldSelectionHandler fieldSelectionHandler = InstanceManager.Instance.Get<FieldSelectionHandler>();
        TeleportFieldSelectEvent fieldSelectionEvent = new TeleportFieldSelectEvent();
        fieldSelectionHandler.confirmedSelectionEvents += fieldSelectionEvent.ConfirmSelectedField;
        fieldSelectionHandler.SetToPlayer(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer());

        CameraModesHandler cameraMovementHandler = InstanceManager.Instance.Get<CameraModesHandler>();
        cameraMovementHandler.SetCameraMode(cameraMovementHandler.fieldFollowMode);
    }

    private void Update()
    {
        if (gameObject.tag == TAG_SELECTION)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                InstanceManager.Instance.Get<FieldSelectionHandler>().SelectNextField();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                InstanceManager.Instance.Get<FieldSelectionHandler>().SelectPreviousField();
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                InstanceManager.Instance.Get<FieldSelectionHandler>().TriggerSelectionEvent();
            }
        }
    }
}