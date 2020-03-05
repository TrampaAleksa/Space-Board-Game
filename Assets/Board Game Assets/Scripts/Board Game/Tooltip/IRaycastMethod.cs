using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRaycastMethod
{
    void HandleRaycast(Ray ray, RaycastHit hit);
}