using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullHandler : MonoBehaviour, IBoardStateInitializer
{
    public const float STARTING_HULL = 120f;
    public const float MAXIMUM_HULL = 120f;

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

    public void SavePlayerState(GameObject player, PlayerBoardState playerState)
    {
        float amount = playerState.hull = player.GetComponent<PlayerHull>().HullPercentage;
        print("Saving the players fuel: " + amount);
    }

    public void SetupPlayerState(GameObject player, PlayerBoardState playerState)
    {
        float amount = playerState.hull;
        player.GetComponent<PlayerHull>().HullPercentage = amount;
        print("Players initial hull set: " + amount);
    }
}