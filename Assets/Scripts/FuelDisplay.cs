using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelDisplay : MonoBehaviour
{
    private FuelHandler fuelHandler;
    void Start()
    {
        fuelHandler = InstanceManager.Instance.Get<FuelHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFuelAmounts();
    }

    private void UpdateFuelAmounts()
    {
        throw new NotImplementedException();
    }
}
