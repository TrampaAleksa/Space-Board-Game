using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockEnemy
{
    public static bool TrySkippingPlayersTurn(PlayerMovement selectedPlayer, int numberOfTurns, GameObject fieldTriggerintEffect)
    {
        TurnHandler turnHandler = InstanceManager.Instance.Get<TurnHandler>();
        turnHandler.PlayerSkipTurns(selectedPlayer.gameObject, numberOfTurns);
        fieldTriggerintEffect.tag = "Untagged";
        return true;
    }
}
