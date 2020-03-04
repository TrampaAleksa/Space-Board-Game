using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerRaycast : MonoBehaviour
{
    private bool howeredOver;
    private FieldHowerTooltip howerTooltip;

    // Start is called before the first frame update
    private void Start()
    {
        howeredOver = false;
        howerTooltip = GameObject.Find("Field hower holder").GetComponent<FieldHowerTooltip>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (howeredOver)
        {
            howerTooltip.ShowTooltip("Floated over");
        }
        else
        {
            howerTooltip.RemoveTooltip();
        }
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Field")))
        {
            howerTooltip = hit.collider.gameObject.GetComponentInChildren<FieldHowerTooltip>();
            howeredOver = true;
            howerTooltip.transform.position = hit.transform.position + (Vector3.up * 3);
            Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
        }
        else
        {
            howeredOver = false;
        }
    }
}