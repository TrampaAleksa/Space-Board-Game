using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPlayerSelectEffectEffect : FieldEffect, IGenericFieldEffect
{
    public override void FinishedEffect()
    {
        InstanceManager.Instance.Get<Inputs>().selectionInputEvents
            -= SelectionInputs;
    }

    public override void TriggerEffect()
    {
        InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer());
        InstanceManager.Instance.Get<Inputs>().selectionInputEvents += SelectionInputs;
        print(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer().name + " Is now choosing: ");
    }

    private void SelectionInputs()
    {
        Debug.Log("input registered");
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AudioManager.Instance.PlaySound("shortClick");
            InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer());
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            AudioManager.Instance.PlaySound("shortClick");
            GetComponent<ISelectionEffect>().ConfirmedSelection();
        }
    }
}
