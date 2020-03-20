using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPlaces 
{
    public static bool TrySwappingPlayers(PlayerMovement firstPlayer, PlayerMovement secondPlayer)
    {
        bool playersOnSameField =
            firstPlayer.currentPlayerField.
            Equals(secondPlayer.currentPlayerField);

        if (playersOnSameField)
            return PlayersOnSameFieldAction();
        else return SwapPlayersAction(firstPlayer, secondPlayer);
    }

    private static bool PlayersOnSameFieldAction()
    {
        return false;
    }

    private static bool SwapPlayersAction(PlayerMovement firstPlayer, PlayerMovement secondPlayer)
    {
        FieldHandler fieldHandler = InstanceManager.Instance.Get<FieldHandler>();
        fieldHandler.SwapTwoPlayers(firstPlayer, secondPlayer);

        return true;
    }

}