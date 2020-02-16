using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHull : MonoBehaviour
{
    private float hullPercentage;

    public float HullPercentage
    {
        get => hullPercentage;
        set {
            hullPercentage = value;
            InstanceManager.Instance.Get<DisplayHandler>().SetShouldUpdate();
        }
    }
    

    void Start()
    {
    }
   
}
