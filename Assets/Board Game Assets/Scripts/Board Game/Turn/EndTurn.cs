using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{
    public void StartNextPlayersTurn()
    {
        StartCoroutine(DelayTurnEnd());
    }

    public IEnumerator DelayTurnEnd()
    {
        yield return new WaitForSeconds(1f);
        
        PlayersHandler playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
        AudioManager.Instance.PlaySound("startOfTurn",false,1f);
        // player ended turn sound
        TooltipHandler tooltipHandler = InstanceManager.Instance.Get<TooltipHandler>();
        tooltipHandler.ShowInfoTooltip(playersHandler.GetCurrentPlayer().GetComponent<PlayerName>().playerName.text + "s turn");

        DiceRollHandler diceRollHandler = InstanceManager.Instance.Get<DiceRollHandler>();
        if (diceRollHandler.DiceIsLocked())
        {
            diceRollHandler.ChangeDiceLockState();
        }

        CameraModesHandler cameraMovementHandler = InstanceManager.Instance.Get<CameraModesHandler>();
        cameraMovementHandler.SetCameraMode<CameraModePlayerFollow>();
    }
}