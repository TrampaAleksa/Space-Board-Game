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
            if (Input.GetKeyDown(KeyCode.K))
            {
                SwapPlaces();
            }
        }
       
    }

    private void SwapPlaces()
    {
        gameObject.tag = "Untagged";

        PlayerMovement triggerringPlayer = playersHandler.players[playerTriggeringIndex].GetComponent<PlayerMovement>();
        PlayerMovement selectedPlayer = currentlySelectedPlayer.GetComponent<PlayerMovement>();

        int p = selectedPlayer.currentPathIndex;
        selectedPlayer.currentPathIndex = triggerringPlayer.currentPathIndex;
        triggerringPlayer.currentPathIndex = p;
        //TODO - extract a method for updating the position to travel to based on the currentPathIndex
        Vector3 v = selectedPlayer.positionToTravelTo;
        selectedPlayer.positionToTravelTo = triggerringPlayer.positionToTravelTo;
        triggerringPlayer.positionToTravelTo = v;
        playersHandler.EndCurrentPlayersTurn();
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

 



