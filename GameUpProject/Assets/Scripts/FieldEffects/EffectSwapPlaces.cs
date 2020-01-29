using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSwapPlaces : FieldEffect
{

    private GameObject currentlySelectedPlayer;
    private int currentlySelectedPlayerIndex;
    private int playerTriggeringIndex;

    public override void TriggerEffect()
    {
        gameObject.tag = "Swap";
        playerTriggeringIndex = playersHandler.currentPlayerIndex;
        currentlySelectedPlayerIndex = playersHandler.NextIndex();
        currentlySelectedPlayer = playersHandler.players[currentlySelectedPlayerIndex];
        print(playersHandler.players[playerTriggeringIndex].name + "Is now choosing: ");
    }

    private void Update()
    {
        if(gameObject.tag == "Swap")
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SelectNextPlayer();
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                if(SwapPlaces())
                playersHandler.EndCurrentPlayersTurn();
            }
        }
       
    }

    private bool SwapPlaces()
    {

        PlayerMovement triggeringPlayer = playersHandler.players[playerTriggeringIndex].GetComponent<PlayerMovement>();
        PlayerMovement selectedPlayer = currentlySelectedPlayer.GetComponent<PlayerMovement>();

        if(triggeringPlayer.currentPathIndex != selectedPlayer.currentPathIndex)
        {
            gameObject.tag = "Untagged";
            int p = selectedPlayer.currentPathIndex;
            selectedPlayer.SetCurrentField(triggeringPlayer.currentPathIndex);
            triggeringPlayer.SetCurrentField(p);
            return true;
        }
        print("Same space, pick a player that isn't in your space!");
        return false;
        
      
    }

    private void SelectNextPlayer()
    {
            //store current index/player locally
            currentlySelectedPlayerIndex = (currentlySelectedPlayerIndex + 1) % playersHandler.players.Length;

            if (currentlySelectedPlayerIndex == playerTriggeringIndex)
                currentlySelectedPlayerIndex = (currentlySelectedPlayerIndex + 1) % playersHandler.players.Length;

            currentlySelectedPlayer = playersHandler.players[currentlySelectedPlayerIndex];
            print("Currently selected player: " + currentlySelectedPlayer);
    }
}

 



