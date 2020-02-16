using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSwapPlaces : FieldEffect
{
    
    public override void TriggerEffect()
    {
        gameObject.tag = TAG_SELECTION;
        InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer(playersHandler.GetCurrentPlayer());
        print(playersHandler.GetCurrentPlayer().name + " Is now choosing: ");
    }

    private void Update()
    {
        if(gameObject.tag == TAG_SELECTION)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer(playersHandler.GetCurrentPlayer());
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

 



