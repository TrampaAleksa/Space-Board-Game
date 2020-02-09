using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : PlayerStateDisplay
{
    private Text displayText;
    public override bool UpdateDisplay()
    {
        GetComponent<Text>().text = InstanceManager.Instance.Get<HealthHandler>().GetPlayerHealth(player).health.ToString();
        return true;
    }

    private void Start()
    {
        displayText = GetComponent<Text>();
    }

}
