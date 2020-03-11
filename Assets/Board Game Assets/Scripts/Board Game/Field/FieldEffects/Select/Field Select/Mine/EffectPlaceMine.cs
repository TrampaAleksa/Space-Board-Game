using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlaceMine : FieldEffect
{
    public override void TriggerEffect()
    {
        print("Place a mine!");
        gameObject.tag = TAG_SELECTION;
        GenericTriggerEffect();

        FieldSelectionHandler fieldSelectionHandler = InstanceManager.Instance.Get<FieldSelectionHandler>();
        MineFieldSelectionEvent fieldSelectionEvent = new MineFieldSelectionEvent();
        InstanceManager.Instance.Get<FieldSelectionHandler>().confirmedSelectionEvents += fieldSelectionEvent.ConfirmSelectedField;
        fieldSelectionHandler.SetToPlayer(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer());
        CameraModesHandler cameraMovementHandler = InstanceManager.Instance.Get<CameraModesHandler>();
        cameraMovementHandler.SetCameraMode(typeof(CameraModeFieldFollow));
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