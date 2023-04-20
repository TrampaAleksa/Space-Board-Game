using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy 
{
    public static bool TryDamagingPlayer(PlayerHull selectedPlayer)
    {
        Damage.DamagePlayer(selectedPlayer.gameObject, EffectDamageEnemy.amountToDamage);
        return true;
    }
 
}