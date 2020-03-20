using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockEnemy 
{

    public static bool TrySkippingPlayersTurn(PlayerMovement selectedPlayer, int numberOfTurns)
    {
        TurnHandler turnHandler = InstanceManager.Instance.Get<TurnHandler>();
        turnHandler.AddPlayerTurnsToSkip(selectedPlayer.gameObject, numberOfTurns);

        return true;
    }

}