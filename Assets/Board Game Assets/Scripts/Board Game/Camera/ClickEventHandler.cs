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
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            eventsOnClick.Invoke();
        }
    }

    public void AddClickEvent(IClickEvent clickEvent)
    {
        eventsOnClick += clickEvent.Clicked;
    }

    public void RemoveClickEvent(IClickEvent clickEvent)
    {
        eventsOnClick -= clickEvent.Clicked;
    }

    public IClickEvent Clicked()
    {
        return this;
    }
}
