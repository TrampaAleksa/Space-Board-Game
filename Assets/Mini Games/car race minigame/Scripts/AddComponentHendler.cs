using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddComponentHendler : MonoBehaviour
{
    public static AddComponentHendler Instance;
    public string[] nameOfWheelColliderObject=new string[] {"WC_FRONTLEFT","WC_FRONTRIGHT","WC_REARLEFT","WC_REARRIGHT"};
    void Awake()
    {
        Instance=this;
    }
}
