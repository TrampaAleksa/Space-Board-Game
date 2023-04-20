using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullHandler : MonoBehaviour
{
    public static float startingHull => GameConfig.GetConfig<HealthConfig>().healthOnStart;
    public static float maximumHull = startingHull;

    public GameObject SetPlayerHull(GameObject player, float value)
    {
        player.GetComponent<PlayerHull>().HullPercentage = value;
        return player;
    }

    public PlayerHull GetPlayerHull(GameObject player)
    {
        return player.GetComponent<PlayerHull>();
    }

    public GameObject DamagePlayer(GameObject player, float value)
    {
        Damage.DamagePlayer(player, value);
        return player;
    }

}