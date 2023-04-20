using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockEnemySelectionEffect : MonoBehaviour, ISelectionEffect
{

    public void ConfirmedSelection()
    {
        PlayerMovement selectedPlayer = InstanceManager.Instance.Get<SelectionHandler>().GetSelectedPlayer().GetComponent<PlayerMovement>();
        if (LockEnemy.TrySkippingPlayersTurn(selectedPlayer, EffectLockEnemy.turnsToLock))
        {
            DisplayActivityTooltip(selectedPlayer);
            InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(gameObject);
        }
    }

    private void DisplayActivityTooltip(PlayerMovement selectedPlayer)
    {
        new ATEnemyLock(
            InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer(),
            selectedPlayer.gameObject
        ).DisplayAT();
    }
}
