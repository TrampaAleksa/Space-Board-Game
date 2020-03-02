using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectionHandler : GenericObjectArray
{
    public GameObject GetSelectedPlayer()
    {
        return CurrentMember();
    }

    public GameObject SelectNextPlayer(GameObject playerSelecting)
    {
        GameObject currentlySelected = SetToNextMember();
        if (currentlySelected == playerSelecting)
            currentlySelected = SetToNextMember();
        print("Currently selected player: " + currentlySelected.name);
        //changed selected player sound?
        CameraMovementHandler cameraMovementHandler = InstanceManager.Instance.Get<CameraMovementHandler>();
        cameraMovementHandler.SetCameraMode(cameraMovementHandler.selectedFolllowMode);
        return currentlySelected;
    }
}