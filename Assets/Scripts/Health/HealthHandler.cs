using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public float startingAmount;
    public GameObject SetPlayersHealth(GameObject player, float value)
    {
        player.GetComponent<PlayerHealth>().health = value;
        return player;
    }

    public PlayerHealth GetPlayerHealth(GameObject player)
    {
        return player.GetComponent<PlayerHealth>();
    }

    public GameObject HealPlayer(GameObject player, float value)
    {
        player.GetComponent<PlayerHealth>().health += value;
        return player;
    }

    public GameObject DamagePlayer(GameObject player, float value)
    {
        player.GetComponent<PlayerHealth>().health -= value;
        return player;
    }

}


