using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplayHandler : MonoBehaviour
{
    public List<PlayerHealthDisplay> healthDisplays;

    private void Start()
    {
        LoopsHandler.LoopDelegate updateDelegate = UpdateDisplays;
        InstanceManager.Instance.Get<LoopsHandler>().Loop(0.2f, updateDelegate);
    }

    private bool UpdateDisplays()
    {
        foreach (var currentDisplay in healthDisplays)
        {
            currentDisplay.UpdateDisplay();
        }
        return true;
    }
}
