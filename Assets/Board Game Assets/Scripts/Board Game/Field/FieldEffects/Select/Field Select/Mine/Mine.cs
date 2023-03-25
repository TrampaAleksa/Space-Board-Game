using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : FieldEffect
{
    private float mineDamage = 20f;

    [HideInInspector]
    public GameObject mineObj;

    public override void TriggerEffect()
    {
        GameObject player = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer();
        InstanceManager.Instance.Get<HullHandler>().DamagePlayer(player, mineDamage);
        
        new ATMineTriggered(player, (int)mineDamage).DisplayAT();
        
        InstanceManager.Instance.Get<FieldEffectHandler>().RemoveEffectFromField(gameObject, this);
        
        Destroy(mineObj);
        Destroy(this);
    }

    public override void FinishedEffect()
    {
        throw new System.NotImplementedException();
    }

}