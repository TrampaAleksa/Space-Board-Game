using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinePlacementClick : MonoBehaviour, IClickEvent
{
    public IClickEvent Clicked()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Field")))
        {
            if (hit.transform != null && hit.collider.gameObject.GetComponentInChildren<Field>() != null)
            {
                print("Clicked on a field!");
                if (hit.collider.gameObject.GetComponent<Mine>() == null)
                    hit.collider.gameObject.AddComponent<Mine>();
                else print("mine already exists");
            }
        }
        return this;
    }

}
