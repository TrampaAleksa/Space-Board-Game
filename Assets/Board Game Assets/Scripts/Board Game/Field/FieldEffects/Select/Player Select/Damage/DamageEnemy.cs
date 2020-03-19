using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : ISelectionEffect
{
    private GameObject fieldOfPlayerSelecting;

    public DamageEnemy(GameObject fieldOfPlayerSelecting)
    {
        this.fieldOfPlayerSelecting = fieldOfPlayerSelecting;
    }

    public static bool TryDamagingPlayer(PlayerHull selectedPlayer, GameObject fieldTriggeringEffect)
    {
        Damage.DamagePlayer(selectedPlayer.gameObject, EffectDamageEnemy.AMOUNT_TO_DAMAGE);
        fieldTriggeringEffect.GetComponent<SelectPlayerEffect>().FinishedSelecting();
        return true;
    }

    public void ConfirmedSelection()
    {
        PlayerHull selectedPlayer = InstanceManager.Instance.Get<SelectionHandler>().GetSelectedPlayer().GetComponent<PlayerHull>();
        if (TryDamagingPlayer(selectedPlayer, fieldOfPlayerSelecting)){
            DisplayInActivityHistory(selectedPlayer.gameObject);
            InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(fieldOfPlayerSelecting);
        }
    }

     private void DisplayInActivityHistory(GameObject selectedPlayer)
    {
        new ATDamagedEnemy(
            InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer(),
            selectedPlayer,
            (int)EffectDamageEnemy.AMOUNT_TO_DAMAGE
        ).DisplayAT();
    }
}