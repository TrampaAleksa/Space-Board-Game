using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamagePlayer : FieldEffect, IGenericFieldEffect
{
    public float damageAmount = 20;

    public override void FinishedEffect()
    {
        string message = new PlayerStatehangedActivityTooltip(
            InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer().GetComponent<PlayerName>().playerName.text,
            (int)damageAmount,
            "damage",
            "took"
            ).BuildActivityTooltip();
        InstanceManager.Instance.Get<ActivityHistoryHandler>().ShowActivityTooltipMessage(message);
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }

    public override void TriggerEffect()
    {
        Damage.DamagePlayer(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer(), damageAmount);
        InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(gameObject);
    }
}