﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSwapPlaces : FieldEffect
{
    
    public override void TriggerEffect()
    {
        gameObject.tag = "Swap";
        InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer();
        print(playersHandler.GetCurrentPlayer().name + "Is now choosing: ");
    }

    private void Update()
    {
        if(gameObject.tag == "Swap")
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer();
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                PlayerMovement triggeringPlayer = playersHandler.GetCurrentPlayer().GetComponent<PlayerMovement>();
                PlayerMovement selectedPlayer = InstanceManager.Instance.Get<SelectionHandler>().GetSelectedPlayer().GetComponent<PlayerMovement>();
                if (SwapPlaces.TrySwappingPlayers(triggeringPlayer, selectedPlayer, gameObject))
                InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
            }
        }
       
    }

}

 



