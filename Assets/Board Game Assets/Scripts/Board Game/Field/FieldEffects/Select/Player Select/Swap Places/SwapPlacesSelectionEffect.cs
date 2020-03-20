using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPlacesSelectionEffect : MonoBehaviour, ISelectionEffect
{
    public void ConfirmedSelection()
    {
        PlayerMovement triggeringPlayer = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer().GetComponent<PlayerMovement>();
        PlayerMovement selectedPlayer = InstanceManager.Instance.Get<SelectionHandler>().GetSelectedPlayer().GetComponent<PlayerMovement>();
        if (SwapPlaces.TrySwappingPlayers(triggeringPlayer, selectedPlayer))
        {
            DisplayInActivityHistory(triggeringPlayer.gameObject, selectedPlayer.gameObject);
            InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(gameObject);
        }
    }

    private void DisplayInActivityHistory(GameObject player1, GameObject player2)
    {
        new ATSwappedPlaces(player1, player2).DisplayAT();
    }
}
