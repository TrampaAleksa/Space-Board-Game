using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICameraMode 
{
    void UpdateCamera(Vector3 offset, float smoothSpeed);
}
