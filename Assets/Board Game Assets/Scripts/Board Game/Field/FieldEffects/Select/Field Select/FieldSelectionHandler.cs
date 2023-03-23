using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSelectionHandler : GenericObjectArray
{

    void Awake()
    {
        gameObjects = InstanceManager.Instance.Get<FieldHandler>().gameObjects;
    }
    public GameObject GetSelectedField()
    {
        return CurrentMember();
    }

    public GameObject SetToPlayersField(GameObject playerSelecting)
    {
        var currentlySelected = SetCurrentMember(playerSelecting.GetComponent<PlayerMovement>().currentPlayerField.IndexInPath);
        SetSelectionIndicator();
        
        return currentlySelected;
    }

    public GameObject SelectNextField()
    {
        GameObject currentlySelected = SetToNextMember();
        print("selected : " + CurrentMember().name);
        SetSelectionIndicator();
        return currentlySelected;
    }

    public GameObject SelectPreviousField()
    {
        GameObject currentlySelected = SetCurrentMember(CurrentMemberIndex - 1);
        print("selected : " + CurrentMember().name);
        SetSelectionIndicator();
        return currentlySelected;
    }
    public Field GetCurrentField()
    {
        return CurrentMember().GetComponent<Field>();
    }

    private void SetSelectionIndicator()
    {
      InstanceManager.Instance.Get<SelectionIndicatorHandler>().SetArrow(GetCurrentField().transform);
    }
}