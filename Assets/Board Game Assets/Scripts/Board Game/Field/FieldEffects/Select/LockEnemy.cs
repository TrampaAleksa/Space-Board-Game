using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockEnemy : ISelectionEffect
{
    private GameObject field;

    public LockEnemy(GameObject field)
    {
        this.field = field;
    }

    public static bool TrySkippingPlayersTurn(PlayerMovement selectedPlayer, int numberOfTurns, GameObject fieldTriggerintEffect)
    {
        TurnHandler turnHandler = InstanceManager.Instance.Get<TurnHandler>();
        turnHandler.AddPlayerTurnsToSkip(selectedPlayer.gameObject, numberOfTurns);
        fieldTriggerintEffect.tag = "Untagged";
        return true;
    }

    public void ConfirmedSelection()
    {
        PlayerMovement selectedPlayer = InstanceManager.Instance.Get<SelectionHandler>().GetSelectedPlayer().GetComponent<PlayerMovement>();
        if (TrySkippingPlayersTurn(selectedPlayer, EffectLockEnemy.TURNS_TO_LOCK, field))
            InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}
