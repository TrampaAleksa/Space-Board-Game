using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericFieldSelectEffect : FieldEffect, IGenericFieldEffect
{
    public override void FinishedEffect()
    {
        InstanceManager.Instance.Get<Inputs>().selectionInputEvents
            -= SelectionInputs;
    }

    public override void TriggerEffect()
    {
        FieldSelectionHandler fieldSelectionHandler = InstanceManager.Instance.Get<FieldSelectionHandler>();

        fieldSelectionHandler.SetToPlayersField(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer());

        CameraModesHandler cameraMovementHandler = InstanceManager.Instance.Get<CameraModesHandler>();
        cameraMovementHandler.SetCameraMode<CameraModeFieldFollow>();

        InstanceManager.Instance.Get<Inputs>().selectionInputEvents += SelectionInputs;
        InstanceManager.Instance.Get<TooltipHandler>().ShowInfoTooltip
            ("Select a field: ");
    }

    private void SelectionInputs()
    {
        Debug.Log("input registered");
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Inputs.PlayInputSound();
            InstanceManager.Instance.Get<FieldSelectionHandler>().SelectNextField();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Inputs.PlayInputSound();
            InstanceManager.Instance.Get<FieldSelectionHandler>().SelectPreviousField();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Inputs.PlayInputSound();
            GetComponent<ISelectionEffect>().ConfirmedSelection();
        }
    }
}
