using System.Collections;
using System.Collections.Generic;
using Board_Game_Assets.Scripts.Board_Game.Field;
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
        InstanceManager.Instance.Get<FieldHandler>().SetFieldHaloColor(gameObject, FieldColor.Empty);
        
        Destroy(mineObj);
        Destroy(this);
    }

    public override void FinishedEffect()
    {
        throw new System.NotImplementedException();
    }

}