using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHandler : MonoBehaviour
{
   public void EndCurrentPlayersTurn()
    {
        PlayersHandler playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
        playersHandler.SetToNextPlayer();
        int nextPlayersTurnsToSkip = playersHandler.GetCurrentPlayer().GetComponent<PlayerMovement>().turnsToSkip;
        if (nextPlayersTurnsToSkip > 0)
        {
            playersHandler.GetCurrentPlayer().GetComponent<PlayerMovement>().turnsToSkip--;
            EndCurrentPlayersTurn();
        }
        else
        {
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
}
