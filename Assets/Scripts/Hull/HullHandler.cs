using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullHandler : MonoBehaviour, IBoardState
{
    public const float startingAmount = 30f;
    public GameObject SetPlayerHull(GameObject player, float value)
    {
        player.GetComponent<PlayerHull>().hull = value;
        return player;
    }

    public PlayerHull GetPlayerHull(GameObject player)
    {
        return player.GetComponent<PlayerHull>();
    }

    public GameObject RepairPlayer(GameObject player, float value)
    {
        player.GetComponent<PlayerHull>().hull += value;
        return player;
    }

    public GameObject DamagePlayer(GameObject player, float value)
    {
        player.GetComponent<PlayerHull>().hull -= value;
        return player;
    }

    public void SaveState()
    {
    }

    public void SetupState()
    {
        foreach (var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            player.GetComponent<PlayerHull>().hull = startingAmount;
            print("Players initial hull set: " + startingAmount);
        }
    }
}


