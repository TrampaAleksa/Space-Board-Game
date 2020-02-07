using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplayHandler : MonoBehaviour
{
    public List<PlayerHealthDisplay> healthDisplays;

    void Update()
    {
        foreach (var currentDisplay in healthDisplays)
        {
            currentDisplay.UpdateDisplay();
        }
    }
}
