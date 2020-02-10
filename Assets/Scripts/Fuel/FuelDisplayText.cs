using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//if we wanted to create a different display method, for instance fuel display progressbar;
//all we would have to do is make another class that extends PlayerFuelDisplay and then implement its method for updating fuel amount.
//Dont forget to add the new script to the FuelDisplayHandler.
public class FuelDisplayText : PlayerStateDisplay
{
    private Text displayText;
    public override bool UpdateDisplay()
    {
        displayText.text = InstanceManager.Instance.Get<FuelHandler>().GetPlayersFuel(player).fuel.ToString();
        return true;
    }

    private void Start()
    {
        displayText = GetComponent<Text>();
    }
}
