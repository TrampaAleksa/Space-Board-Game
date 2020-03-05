using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinePlacementClick : MonoBehaviour, IClickEvent
{
    private MinePlacementClickEvent minePlacementEventImpl;

    private void Start()
    {
        minePlacementEventImpl = new MinePlacementClickEvent();
    }

    public IClickEvent Clicked()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Field")))
        {
            minePlacementEventImpl.FieldClickAction(this, hit.collider.gameObject);
        }
        return this;
    }
}