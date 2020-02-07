using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelDisplayText : PlayerFuelDisplay
{
    private Text text;
    public override void UpdateFuelAmount()
    {
        text.text = InstanceManager.Instance.Get<FuelHandler>().GetPlayersFuel(player).fuel.ToString();
    }

    private void Start()
    {
        text = GetComponent<Text>();
    }
}
