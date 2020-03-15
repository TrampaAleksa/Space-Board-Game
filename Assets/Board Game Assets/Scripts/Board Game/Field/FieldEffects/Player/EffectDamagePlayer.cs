using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamagePlayer : FieldEffect
{
    public float damageAmount = 20;

    public override void FinishedEffect()
    {
        throw new System.NotImplementedException();
    }

    public override void TriggerEffect()
    {
        GenericTriggerEffect();
        Damage.DamagePlayer(playersHandler.GetCurrentPlayer(), damageAmount);
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}