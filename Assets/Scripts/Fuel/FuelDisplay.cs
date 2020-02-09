using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStateDisplay : MonoBehaviour
{
    public GameObject player;

    public abstract void UpdateDisplay();
    
}
