using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerClass : MonoBehaviour
{

    public static CameraControllerClass Instance;
    private void Awake()
    {
        Instance = this;
    }
}
