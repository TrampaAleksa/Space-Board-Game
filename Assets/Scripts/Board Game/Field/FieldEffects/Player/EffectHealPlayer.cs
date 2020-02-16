using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHealPlayer : FieldEffect
{
    public float amountToHeal = 10;
    public override void TriggerEffect()
    {
        Repair.RepairPlayer(playersHandler.GetCurrentPlayer(), amountToHeal, HullHandler.MAXIMUM_HULL);
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }

}
