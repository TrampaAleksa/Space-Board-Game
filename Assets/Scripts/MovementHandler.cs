﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    public FieldPath path;
    private void Start()
    {
        path = InstanceManager.Instance.Get<FieldPath>();
    }
    
}
