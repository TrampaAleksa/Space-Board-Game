using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldHowerRaycast : MonoBehaviour, IRaycastMethod
{
    private FieldHowerTooltip howerTooltip;
    public Vector3 offset = new Vector3(0, 2, 1);

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
            howerTooltip.transform.parent.eulerAngles = new Vector3(howerTooltip.transform.parent.eulerAngles.x,
                Camera.main.transform.eulerAngles.y,
                howerTooltip.transform.parent.eulerAngles.z);
        }
        else
        {
            howerTooltip.RemoveTooltip();
        }
    }
}