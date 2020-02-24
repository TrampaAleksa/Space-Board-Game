﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHandler : MonoBehaviour, IBoardState
{
   public void EndCurrentPlayersTurn()
    {
        PlayersHandler playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
        playersHandler.SetToNextPlayer();
        bool brokenEngines = playersHandler.GetCurrentPlayer().GetComponent<PlayerMovement>().EnginesBroken();
        if (brokenEngines)
        {
            SkipPlayersTurn(playersHandler.GetCurrentPlayer());
            EndCurrentPlayersTurn();
        }
        else
        {
            TooltipHandler tooltipHandler = InstanceManager.Instance.Get<TooltipHandler>();
            tooltipHandler.ShowTooltipForGivenTime
                (tooltipHandler.FindTooltipByGameObjectName("TooltipMessage"),
                playersHandler.GetCurrentPlayer().name + "s turn",
                TooltipHandler.TOOLTIP_TIME_SHORT);
            DiceRollHandler diceRollHandler = InstanceManager.Instance.Get<DiceRollHandler>();
            if (diceRollHandler.DiceIsLocked())
            {
                diceRollHandler.ChangeDiceLockState();
            }
        }
       
    }

    public GameObject PlayerSkipTurns(GameObject player, int turnsToSkip)
    {
        player.GetComponent<PlayerMovement>().turnsToSkip += turnsToSkip;
        return player;
    }

    public int SkipPlayersTurn(GameObject player)
    {
        player.GetComponent<PlayerMovement>().turnsToSkip--;
        return player.GetComponent<PlayerMovement>().turnsToSkip;
    }

    public void SaveState()
    {
        int i = 0;
        foreach (var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            int turnsToSkip = InstanceManager.Instance.Get<BoardStateHandler>().playerBoardStates[i].turnsToSkip = player.GetComponent<PlayerMovement>().turnsToSkip;
            print("Saving the players turns to skip : " + turnsToSkip);
            i++;
        }
    }

    public void SetupState()
    {
        int i = 0;
        foreach (var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            int turnsToSkip = InstanceManager.Instance.Get<BoardStateHandler>().playerBoardStates[i].turnsToSkip;
            player.GetComponent<PlayerMovement>().turnsToSkip = turnsToSkip;
            i++;
        }
    }

   
}