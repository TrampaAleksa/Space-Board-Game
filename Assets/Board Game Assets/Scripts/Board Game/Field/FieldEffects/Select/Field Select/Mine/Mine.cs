using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : FieldEffect
{
    private float mineDamage = 20f;

    public override void TriggerEffect()
    {
        GameObject player = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer();
        InstanceManager.Instance.Get<HullHandler>().DamagePlayer(player, mineDamage);
        DisplayInActivityHistory();
        InstanceManager.Instance.Get<FieldEffectHandler>().RemoveEffectFromField(gameObject, this);
        Destroy(this);
    }

    public override void FinishedEffect()
    {
        throw new System.NotImplementedException();
    }

     private void DisplayInActivityHistory()
    {
        string message = new ATMineTriggered(
           InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer(),
           (int)mineDamage
           ).BuildActivityTooltip();
        InstanceManager.Instance.Get<ActivityHistoryHandler>().ShowActivityTooltipMessage(message);
    }
}