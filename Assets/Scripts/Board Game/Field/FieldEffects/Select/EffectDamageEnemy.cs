using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamageEnemy : FieldEffect
{
    public const float amountToDamage = 20f;
    public override void TriggerEffect()
    {
        gameObject.tag = TAG_SELECTION;
        InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer(playersHandler.GetCurrentPlayer());
        print(playersHandler.GetCurrentPlayer().name + " Is now choosing: ");
        print("Damage Another player!");
    }

    private void Update()
    {
        if (gameObject.tag == TAG_SELECTION)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer(playersHandler.GetCurrentPlayer());
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                PlayerHull selectedPlayer = InstanceManager.Instance.Get<SelectionHandler>().GetSelectedPlayer().GetComponent<PlayerHull>();
                if (TryDamagingPlayer(selectedPlayer))
                    InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
            }
        }

    }

    public bool TryDamagingPlayer(PlayerHull selectedPlayer)
    {
        HullHandler hullHandler = InstanceManager.Instance.Get<HullHandler>();
        hullHandler.DamagePlayer(selectedPlayer.gameObject, amountToDamage);
        gameObject.tag = "Untagged";
        return true;
    }
}
