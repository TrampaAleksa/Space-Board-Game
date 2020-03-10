﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSelectionHandler : GenericObjectArray
{
    public event Action<GameObject> confirmedSelectionEvents;

    public GameObject GetSelectedField()
    {
        return CurrentMember();
    }

    public GameObject SetToPlayer(GameObject playerSelecting)
    {
        return SetCurrentMember(playerSelecting.GetComponent<PlayerMovement>().currentPlayerField.IndexInPath);
    }

    public GameObject SelectNextField()
    {
        GameObject currentlySelected = SetToNextMember();
        print("selected : " + CurrentMember().name);
        return currentlySelected;
    }

    public GameObject SelectPreviousField()
    {
        GameObject currentlySelected = SetCurrentMember(CurrentMemberIndex - 1);
        print("selected : " + CurrentMember().name);
        return currentlySelected;
    }

    public GameObject TriggerSelectionEvent()
    {
        confirmedSelectionEvents?.Invoke(CurrentMember());
        return CurrentMember();
    }
}