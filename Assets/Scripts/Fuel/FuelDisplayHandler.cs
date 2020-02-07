using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuelDisplayHandler : MonoBehaviour
{
    public List<PlayerStateDisplay> fuelDisplays;
    private void Update()
    {
        foreach(var currentDisplay in fuelDisplays)
        {
            currentDisplay.UpdateDisplay();
        }
    }

}
