using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : FieldEffect
{
    private float mineDamage = 20f;

    public override void TriggerEffect()
    {
        print("YOU STEPPED ON A MINE");
        GameObject player = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer();
        InstanceManager.Instance.Get<HullHandler>().DamagePlayer(player, mineDamage);
        Destroy(this);
    }
}