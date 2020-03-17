using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectFieldEffect : SelectEffect
{
    public override void GenericSelectTrigger()
    {
        FieldSelectionHandler fieldSelectionHandler = InstanceManager.Instance.Get<FieldSelectionHandler>();

        fieldSelectionHandler.SetToPlayer(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer());

        CameraModesHandler cameraMovementHandler = InstanceManager.Instance.Get<CameraModesHandler>();
        cameraMovementHandler.SetCameraMode<CameraModeFieldFollow>();

        InstanceManager.Instance.Get<Inputs>().selectionInputEvents += SelectionInputs;
        print(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer().name + " Is now choosing: ");
    }

    public override void SelectionInputs()
    {
        print("input registered");
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
            selectionEffect?.ConfirmedSelection();
        }
    }

    public override void FinishedSelecting()
    {
        InstanceManager.Instance.Get<Inputs>().selectionInputEvents
            -= SelectionInputs;
    }
}