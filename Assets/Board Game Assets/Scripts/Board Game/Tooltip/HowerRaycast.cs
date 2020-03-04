using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowerRaycast : MonoBehaviour
{
    private FieldHowerTooltip howerTooltip;

    private void Start()
    {
        howerTooltip = GameObject.Find("Field hower holder").GetComponent<FieldHowerTooltip>();
    }

    public void HoweredOverFieldAction(Ray ray, RaycastHit hit)
    {
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