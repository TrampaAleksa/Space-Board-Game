using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenEngines : MonoBehaviour
{
    public static void BrokenEngineAction()
    {
        // broken engine sound
        GameObject player = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer();
        InstanceManager.Instance.Get<TooltipHandler>()
            .ShowPlayersTooltip(player, "Engines Broke");
        SkipPlayersTurn(player);
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }

    public static int SkipPlayersTurn(GameObject player)
    {
        player.GetComponent<PlayerMovement>().turnsToSkip--;
        return player.GetComponent<PlayerMovement>().turnsToSkip;
    }
}