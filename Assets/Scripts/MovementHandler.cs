using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    protected FieldHandler path;
    private void Start()
    {
        path = InstanceManager.Instance.Get<FieldHandler>();
    }
    
}
