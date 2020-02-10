using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelHandler : MonoBehaviour, IBoardState
{
    public float startingAmount = 50;

    public PlayerFuel GetPlayersFuel(GameObject player)
    {
        return player.GetComponent<PlayerFuel>();
    }

    public GameObject SetPlayersFuel(GameObject player, float value)
    {
        PlayerFuel playerFuel = GetPlayersFuel(player);
        playerFuel.fuel = value;
        return player;
    }

    public GameObject AddFuelToPlayer(GameObject player, float amount)
    {
        PlayerFuel playerFuel = GetPlayersFuel(player);
        playerFuel.fuel += amount;
        return player;
    }

    public void SaveState()
    {
    }

    public void SetupState()
    {
        int i = 0;
        foreach(var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            float amount = InstanceManager.Instance.Get<BoardStateHandler>().playerBoardStates[i].fuel;
            player.GetComponent<PlayerFuel>().fuel = amount;
            print("Players initial fuel set: " + amount);
            i++;
        }
      
    }
}
