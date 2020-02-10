using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPlaces 
{
   public static bool TrySwappingPlayers(PlayerMovement firstPlayer, PlayerMovement secondPlayer, GameObject fieldTriggeringSwap)
    {
        bool playersOnSameField = 
            firstPlayer.currentPlayerField.IndexInPath
            == secondPlayer.currentPlayerField.IndexInPath;

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
        int p = secondPlayer.currentPlayerField.IndexInPath;

        FieldHandler fieldHandler = InstanceManager.Instance.Get<FieldHandler>();
        fieldHandler.SetCurrentField(firstPlayer.currentPlayerField.IndexInPath, secondPlayer.gameObject);
        fieldHandler.SetCurrentField(p, firstPlayer.gameObject);

        return true;
    }
}
