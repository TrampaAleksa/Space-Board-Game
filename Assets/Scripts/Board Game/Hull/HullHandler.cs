using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullHandler : MonoBehaviour, IBoardState
{
    public const float startingAmount = 100f;
    public const float maximumAmount = 100f;

    public GameObject SetPlayerHull(GameObject player, float value)
    {
        player.GetComponent<PlayerHull>().hullPercentage = value;
        return player;
    }

    public PlayerHull GetPlayerHull(GameObject player)
    {
        return player.GetComponent<PlayerHull>();
    }

    public GameObject RepairPlayer(GameObject player, float value)
    {
        PlayerHull playerHull = player.GetComponent<PlayerHull>();
        playerHull.hullPercentage += value;
        if (playerHull.hullPercentage >= 100)
        {
            playerHull.hullPercentage = 100f;
        }

        return player;
    }

    public GameObject DamagePlayer(GameObject player, float value)
    {
        player.GetComponent<PlayerHull>().hullPercentage -= value;
        if(player.GetComponent<PlayerHull>().hullPercentage <= 0)
        {
            player.GetComponent<PlayerCheckpoint>().RespawnAtCheckpoint();
        }
        return player;
    }

    public void SaveState()
    {
        int i = 0;
        foreach (var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            float amount = InstanceManager.Instance.Get<BoardStateHandler>().playerBoardStates[i].hull = player.GetComponent<PlayerHull>().hullPercentage;
            print("Saving the players fuel: " + amount);
            i++;
        }
    }

    public void SetupState()
    {
        int i = 0;
        foreach (var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            float amount = InstanceManager.Instance.Get<BoardStateHandler>().playerBoardStates[i].hull;
            player.GetComponent<PlayerHull>().hullPercentage = amount;
            print("Players initial hull set: " + amount);
            i++;
        }
    }
}


