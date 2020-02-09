using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionHandler : GenericObjectArray
{
    private int currentlySelectedPlayerIndex = 0;

    public int CurrentlySelectedPlayerIndex { get => currentlySelectedPlayerIndex; set => currentlySelectedPlayerIndex = value; }

    public GameObject GetSelectedPlayer()
    {
        return CurrentMember();
    }

    public GameObject SelectNextPlayer(GameObject playerSelecting)
    {
        GameObject currentlySelected = SetToNextMember();
        if(currentlySelected == playerSelecting)
            currentlySelected = SetToNextMember();
        print("Currently selected player: " + currentlySelected.name);
        return currentlySelected;
    }
}
