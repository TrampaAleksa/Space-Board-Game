using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemySelectionEffect : MonoBehaviour, ISelectionEffect
{

    public void ConfirmedSelection()
    {
        PlayerHull selectedPlayer = InstanceManager.Instance.Get<SelectionHandler>().GetSelectedPlayer().GetComponent<PlayerHull>();
        if (DamageEnemy.TryDamagingPlayer(selectedPlayer)){
            DisplayInActivityHistory(selectedPlayer.gameObject);
            InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(gameObject);
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
