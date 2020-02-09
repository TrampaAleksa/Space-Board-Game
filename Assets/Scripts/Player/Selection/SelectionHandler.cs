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
        return playersHandler.MemberWithIndex(CurrentlySelectedPlayerIndex);
    }

    public GameObject SelectNextPlayer()
    {
        PlayersHandler playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
        int playersLength = playersHandler.gameObjects.Length;

        CurrentlySelectedPlayerIndex = (CurrentlySelectedPlayerIndex + 1) % playersLength;

        if(playersHandler.MemberWithIndex(CurrentlySelectedPlayerIndex) == playersHandler.CurrentMember())
        {
            //if (CurrentlySelectedPlayerIndex == playersHandler.CurrentPlayerIndex)
            CurrentlySelectedPlayerIndex = (CurrentlySelectedPlayerIndex + 1) % playersLength;
        }

        GameObject currentlySelectedPlayer = playersHandler.MemberWithIndex(CurrentlySelectedPlayerIndex);
        print("Currently selected player: " + currentlySelectedPlayer.name);
        return currentlySelectedPlayer;
    }
}
