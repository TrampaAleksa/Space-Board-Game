using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryHandler 
{
    public  static void Win(GameObject player)
    {
        Debug.Log("PLAYER: " + player.name + " WON THE GAME!");
        InstanceManager.Instance.Get<TooltipHandler>().ShowPlayersTooltip(player, "WON THE GAME");
    }
    
    public  static bool CheckGameWon(float playerFuel)
    {
        return playerFuel >= FuelHandler.winningAmount;
    }
}
