using System.Collections;
using System.Collections.Generic;
using Board_Game_Assets.Scripts.Board_Game.Tooltip.Activity_History.Activities;
using UnityEngine;

public class BrokenEngines : MonoBehaviour
{
    public static void BrokenEngineAction()
    {
        // broken engine sound
        GameObject player = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer();
        
        InstanceManager.Instance.Get<TooltipHandler>()
            .ShowPlayersTooltip(player, "Engines Broke");
        new ATPlayerLockedTurnSkip(player).DisplayAT();
        
        SkipPlayersTurn(player);
        AudioManager.Instance.PlaySound(AudioManager.OVERHEAT, false, 1);
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }

    public static int SkipPlayersTurn(GameObject player)
    {
        player.GetComponent<PlayerMovement>().turnsToSkip--;
        return player.GetComponent<PlayerMovement>().turnsToSkip;
    }
}