using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerRaycastHandler : MonoBehaviour
{
    private FieldHowerTooltip howerTooltip;

    //public delegate void PointerEvents(Ray ray, RaycastHit hit);

    private void Start()
    {
        howerTooltip = GameObject.Find("Field hower holder").GetComponent<FieldHowerTooltip>();
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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