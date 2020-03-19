using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamagePlayer : FieldEffect, IGenericFieldEffect
{
    public float damageAmount = 20;

    public override void FinishedEffect()
    {
        new ATPlayerDamaged(
            InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer(),
            (int)damageAmount
        ).DisplayAT();
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }

    public override void TriggerEffect()
    {
        Damage.DamagePlayer(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer(), damageAmount);
        InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(gameObject);
    }

}