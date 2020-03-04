using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointerRaycastHandler : MonoBehaviour
{
    private RaycastHit hit;

    public delegate void PointerRaycastEvents(Ray ray, RaycastHit hit);

    private PointerRaycastEvents pointerRaycastEvents;

    private void Awake()
    {
        pointerRaycastEvents = null;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (pointerRaycastEvents != null)
        {
            pointerRaycastEvents.Invoke(ray, hit);
            print("invoking");
        }
    }

    public void AddPointerRaycastToEvents(IRaycastMethod raycastMethod)
    {
        print("adding method");
        pointerRaycastEvents += raycastMethod.HandleRaycast;
    }
}