using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEventHandler : MonoBehaviour, IClickEvent
{
    public delegate IClickEvent ClickEvents();

    private ClickEvents eventsOnClick;

    private void Start()
    {
        eventsOnClick = Clicked;
        eventsOnClick += gameObject.AddComponent<MinePlacementClick>().Clicked;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            eventsOnClick.Invoke();
        }
    }

    private void AddClickEvent(IClickEvent clickEvent)
    {
        eventsOnClick += clickEvent.Clicked;
    }

    private void RemoveClickEvent(IClickEvent clickEvent)
    {
        eventsOnClick -= clickEvent.Clicked;
    }

    public IClickEvent Clicked()
    {
        print("Default click event");
        return this;
    }
}
