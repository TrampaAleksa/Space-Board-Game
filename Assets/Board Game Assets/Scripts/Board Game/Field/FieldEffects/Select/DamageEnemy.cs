using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : ISelectionEffect
{
    private GameObject field;

    public DamageEnemy(GameObject field)
    {
        this.field = field;
    }

    public static bool TryDamagingPlayer(PlayerHull selectedPlayer, GameObject fieldTriggeringEffect)
    {
        Damage.DamagePlayer(selectedPlayer.gameObject, EffectDamageEnemy.AMOUNT_TO_DAMAGE);
        fieldTriggeringEffect.tag = "Untagged";
        fieldTriggeringEffect.GetComponent<SelectPlayerEffect>().FinishedSelecting();
        return true;
    }

    public void ConfirmedSelection()
    {
        PlayerHull selectedPlayer = InstanceManager.Instance.Get<SelectionHandler>().GetSelectedPlayer().GetComponent<PlayerHull>();
        if (TryDamagingPlayer(selectedPlayer, field))
            InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}