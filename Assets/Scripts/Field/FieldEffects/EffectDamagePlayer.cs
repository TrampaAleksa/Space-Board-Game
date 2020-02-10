using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamagePlayer : FieldEffect
{
    public float damageAmount = 10;
    public override void TriggerEffect()
    {
        InstanceManager.Instance.Get<HullHandler>().DamagePlayer(playersHandler.GetCurrentPlayer(), damageAmount);
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}
