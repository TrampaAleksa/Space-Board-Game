using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPlaces 
{
   public static bool TrySwappingPlayers(PlayerMovement firstPlayer, PlayerMovement secondPlayer, GameObject fieldTriggeringSwap)
    {
        bool playersOnSameField = firstPlayer.playersCurrentPathIndex == secondPlayer.playersCurrentPathIndex;
        if (playersOnSameField)
            return PlayersOnSameFieldAction();
        else return SwapPlayersAction(firstPlayer, secondPlayer, fieldTriggeringSwap);
    }

    private static bool PlayersOnSameFieldAction()
    {
        return false;
    }

    private static bool SwapPlayersAction(PlayerMovement firstPlayer, PlayerMovement secondPlayer, GameObject firstPlayersField)
    {
        firstPlayersField.tag = "Untagged";
        int p = secondPlayer.playersCurrentPathIndex;

        FieldHandler fieldHandler = InstanceManager.Instance.Get<FieldHandler>();
        fieldHandler.SetCurrentField(firstPlayer.playersCurrentPathIndex, secondPlayer.gameObject);
        fieldHandler.SetCurrentField(p, firstPlayer.gameObject);

        return true;
    }
}
