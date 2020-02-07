using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuelDisplayHandler : MonoBehaviour
{
    public List<PlayerFuelDisplay> fuelDisplays;
    private void Update()
    {
        foreach(var currentDisplay in fuelDisplays)
        {
            currentDisplay.UpdateFuelAmount();
        }
    }

}
