using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowerRaycast : MonoBehaviour, IRaycastMethod
{
    private FieldHowerTooltip howerTooltip;

    private void Start()
    {
        howerTooltip = GameObject.Find("Field hower holder").GetComponent<FieldHowerTooltip>();
        InstanceManager.Instance.Get<PointerRaycastHandler>().AddPointerRaycastToEvents(this);
    }

    public void HandleRaycast(Ray ray, RaycastHit hit)
    {
        print("Handling raycast");
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Field")))
        {
            howerTooltip = hit.collider.gameObject.GetComponentInChildren<FieldHowerTooltip>();
            howerTooltip.ShowTooltip("Floated over");
            howerTooltip.transform.position = hit.transform.position + (Vector3.up * 3);
        }
        else
        {
            howerTooltip.RemoveTooltip();
        }
    }
}