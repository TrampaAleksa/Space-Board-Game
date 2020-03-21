using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFuel
{
    public  void GameWon(GameObject player)
    {
        Debug.Log("PLAYER: " + player.name + " WON THE GAME!");
        InstanceManager.Instance.Get<TooltipHandler>().ShowPlayersTooltip(player, "WON THE GAME");
    }

    public  void ShowPlayerGainedFuelTooltip(GameObject player, float amount, bool showTooltip)
    {
        if (showTooltip)
            InstanceManager.Instance.Get<TooltipHandler>().ShowPlayersTooltip(player, "+" + amount + " fuel");
    }
    
    public  IEnumerator AddFuelLerp(PlayerFuel playerFuel, float amountAfterAdding)
    {
        var amountPerIncrement = 1f;
        playerFuel.fuel += amountPerIncrement;
        yield return new WaitForSeconds(0.1f);
        if (playerFuel.fuel < amountAfterAdding)
            yield return AddFuelLerp(playerFuel, amountAfterAdding);
    }
}