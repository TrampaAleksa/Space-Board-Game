using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamagePlayer : FieldEffect
{
    public float damageAmount = 10;
    public override void TriggerEffect()
    {
        InstanceManager.Instance.Get<HealthHandler>().DamagePlayer(playersHandler.GetCurrentPlayer(), damageAmount);
        playersHandler.EndCurrentPlayersTurn();
    }
}
