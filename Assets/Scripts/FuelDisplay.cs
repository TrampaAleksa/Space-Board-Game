using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerFuelDisplay : MonoBehaviour
{
    private FuelHandler fuelHandler;
    public GameObject player;
    void Start()
    {
        fuelHandler = InstanceManager.Instance.Get<FuelHandler>();
    }

    public abstract void UpdateFuelAmount();
    
}
