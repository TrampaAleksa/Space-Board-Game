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
        print(currentlySelectedPlayer);
        //playersHandler.EndCurrentPlayersTurn();
    }

    private void Update()
    {
        if(gameObject.tag == "Swap")
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SelectNextPlayer();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SwapPlaces();
            }
        }
       
    }

    private void SwapPlaces()
    {
        
    }

    private void SelectNextPlayer()
    {
            //store current index/player locally
            currentlySelectedPlayerIndex = (currentlySelectedPlayerIndex + 1) % playersHandler.players.Length;

            if (currentlySelectedPlayerIndex == playerTriggeringIndex)
                currentlySelectedPlayerIndex = (currentlySelectedPlayerIndex + 1) % playersHandler.players.Length;

            currentlySelectedPlayer = playersHandler.players[currentlySelectedPlayerIndex];
            print(currentlySelectedPlayer);
    }
}

 



