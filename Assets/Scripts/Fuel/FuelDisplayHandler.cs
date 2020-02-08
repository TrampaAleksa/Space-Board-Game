using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuelDisplayHandler : MonoBehaviour
{
    public List<PlayerStateDisplay> fuelDisplays;

    private void Start()
    {
        LoopsHandler.LoopDelegate updateDelegate = UpdateDisplays;
        InstanceManager.Instance.Get<LoopsHandler>().Loop(0.2f, updateDelegate);
    }

    private bool UpdateDisplays()
    {
        foreach (var currentDisplay in fuelDisplays)
        {
            currentDisplay.UpdateDisplay();
        }
        return true;
    }

}
