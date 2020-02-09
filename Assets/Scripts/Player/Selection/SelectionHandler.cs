using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionHandler : MonoBehaviour
{
    private int currentlySelectedPlayerIndex = 0;

    public int CurrentlySelectedPlayerIndex { get => currentlySelectedPlayerIndex; set => currentlySelectedPlayerIndex = value; }

    public GameObject GetSelectedPlayer()
    {
        PlayersHandler playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
        return playersHandler.players[CurrentlySelectedPlayerIndex];
    }

    public GameObject SelectNextPlayer()
    {
        PlayersHandler playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
        CurrentlySelectedPlayerIndex = (CurrentlySelectedPlayerIndex + 1) % playersHandler.players.Length;

        if (CurrentlySelectedPlayerIndex == playersHandler.CurrentPlayerIndex)
            CurrentlySelectedPlayerIndex = (CurrentlySelectedPlayerIndex + 1) % playersHandler.players.Length;

        GameObject currentlySelectedPlayer = playersHandler.players[CurrentlySelectedPlayerIndex];
        print("Currently selected player: " + currentlySelectedPlayer.name);
        return currentlySelectedPlayer;
    }
}
