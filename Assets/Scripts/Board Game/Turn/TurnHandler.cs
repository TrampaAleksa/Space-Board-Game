using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHandler : MonoBehaviour
{
   public void EndCurrentPlayersTurn()
    {
        PlayersHandler playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
        playersHandler.SetToNextPlayer();
        //playersHandler.CurrentPlayerIndex = (++playersHandler.CurrentPlayerIndex) % playersHandler.players.Length;
        TooltipHandler tooltipHandler = InstanceManager.Instance.Get<TooltipHandler>();
        tooltipHandler.ShowTooltipForGivenTime
            (tooltipHandler.FindTooltipByGameObjectName("TooltipMessage"),
            playersHandler.GetCurrentPlayer().name + "s turn",
            TooltipHandler.TOOLTIP_TIME_SHORT);
        DiceRollHandler diceRollHandler = InstanceManager.Instance.Get<DiceRollHandler>();
        if (diceRollHandler.DiceIsLocked())
        {
            diceRollHandler.ChangeDiceLockState();
        }
    }
}
