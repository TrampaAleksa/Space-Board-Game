using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLockEnemy : FieldEffect
{
    public const int numberOfTurns = 1;
    public override void TriggerEffect()
    {
        gameObject.tag = TAG_SELECTION;
        InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer(playersHandler.GetCurrentPlayer());
        print(playersHandler.GetCurrentPlayer().name + " Is now choosing: ");
        print("Break another players engines!");
    }

    private void Update()
    {
        if (gameObject.tag == TAG_SELECTION)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer(playersHandler.GetCurrentPlayer());
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                PlayerMovement selectedPlayer = InstanceManager.Instance.Get<SelectionHandler>().GetSelectedPlayer().GetComponent<PlayerMovement>();
                if (TrySkippingPlayersTurn(selectedPlayer))
                    InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
            }
        }

    }

    public bool TrySkippingPlayersTurn(PlayerMovement selectedPlayer)
    {
        TurnHandler turnHandler = InstanceManager.Instance.Get<TurnHandler>();
        turnHandler.PlayerSkipTurns(selectedPlayer.gameObject, numberOfTurns);
        gameObject.tag = "Untagged";
        return true;
    }
}
