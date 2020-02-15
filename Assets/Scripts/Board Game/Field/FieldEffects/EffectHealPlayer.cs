using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHealPlayer : FieldEffect
{
    public float amountToHeal = 10;
    public override void TriggerEffect()
    {
        InstanceManager.Instance.Get<HullHandler>().RepairPlayer(playersHandler.GetCurrentPlayer(), amountToHeal);
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }

}
