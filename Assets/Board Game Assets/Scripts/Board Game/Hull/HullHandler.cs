using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullHandler : MonoBehaviour, IBoardState
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

    public void SaveState()
    {
        int i = 0;
        foreach (var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            float amount = InstanceManager.Instance.Get<BoardStateHandler>().playerBoardStates[i].hull = player.GetComponent<PlayerHull>().HullPercentage;
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
            player.GetComponent<PlayerHull>().HullPercentage = amount;
            print("Players initial hull set: " + amount);
            i++;
        }
    }
}


