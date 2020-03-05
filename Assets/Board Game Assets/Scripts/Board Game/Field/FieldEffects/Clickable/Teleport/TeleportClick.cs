using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportClick : MonoBehaviour, IClickEvent
{
    public const int maximumDistanceAllowed = 3;
    public TeleportClickEvent clickEventImpl;

    private void Start()
    {
        clickEventImpl = new TeleportClickEvent();
    }

    public IClickEvent Clicked()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Field")))
        {
            clickEventImpl.FieldClickAction(this, hit.collider.gameObject);
        }
        return this;
    }
}