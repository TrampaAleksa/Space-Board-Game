using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{
    public static void StartNextPlayersTurn()
    {
        PlayersHandler playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
        // player ended turn sound
        TooltipHandler tooltipHandler = InstanceManager.Instance.Get<TooltipHandler>();
        tooltipHandler.ShowInfoTooltip(playersHandler.GetCurrentPlayer().name + "s turn");

        DiceRollHandler diceRollHandler = InstanceManager.Instance.Get<DiceRollHandler>();
        if (diceRollHandler.DiceIsLocked())
        {
            diceRollHandler.ChangeDiceLockState();
        }

        CameraModesHandler cameraMovementHandler = InstanceManager.Instance.Get<CameraModesHandler>();
        cameraMovementHandler.SetCameraMode<CameraModePlayerFollow>();
    }
}