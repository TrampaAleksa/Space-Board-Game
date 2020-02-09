using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFuel : MonoBehaviour
{
    public float fuel;
    private FuelHandler fuelHandler;
    // Start is called before the first frame update
    void Start()
    {
        fuelHandler = InstanceManager.Instance.Get<FuelHandler>();
    }

    public void Initialize()
    {
        fuelHandler = InstanceManager.Instance.Get<FuelHandler>();
        fuel = fuelHandler.startingAmount;
        print("Players initial fuel set: " + fuel);
    }

}
