using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy 
{
    public static bool TryDamagingPlayer(PlayerHull selectedPlayer, float amountToDamage, GameObject fieldTriggeringEffect)
    {
        HullHandler hullHandler = InstanceManager.Instance.Get<HullHandler>();
        hullHandler.DamagePlayer(selectedPlayer.gameObject, amountToDamage);
        fieldTriggeringEffect.tag = "Untagged";
        return true;
    }
}
