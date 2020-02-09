using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private HealthHandler healthHandler;
    public float health;
    void Start()
    {
        healthHandler = InstanceManager.Instance.Get<HealthHandler>();
    }

    public void Initialize()
    {
        healthHandler = InstanceManager.Instance.Get<HealthHandler>();
        health = healthHandler.startingAmount;
    }

}
