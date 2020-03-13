using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHullDisplayBar : PlayerStateDisplay
{
    public bool shouldUpdate = true;

    public Image[] barSteps;

    public override bool UpdateDisplay()
    {
        if (shouldUpdate)
        {
            int indexToActivateTo = (int)player.GetComponent<PlayerHull>().HullPercentage / 10;
            for (int i = 0; i < indexToActivateTo; i++)
            {
                //barSteps[i].gameObject.SetActive(true);
                barSteps[i].color = new Color(barSteps[i].color.r, barSteps[i].color.g, barSteps[i].color.b, 1);
            }
            for (int i = indexToActivateTo; i < barSteps.Length; i++)
            {
                barSteps[i].color = new Color(barSteps[i].color.r, barSteps[i].color.g, barSteps[i].color.b, 0);
            }
            shouldUpdate = false;
        }
        return true;
    }
}