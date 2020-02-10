using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHullDisplay : PlayerStateDisplay
{
    private Text displayText;
    public override bool UpdateDisplay()
    {
        GetComponent<Text>().text = InstanceManager.Instance.Get<HullHandler>().GetPlayerHull(player).hull.ToString();
        return true;
    }

    private void Awake()
    {
        displayText = GetComponent<Text>();
    }

}
