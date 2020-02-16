using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectStealFuel : SelectOnTrigger
{
    public const float AMOUNT_TO_STEAL = 20f;

    private void Awake()
    {
        selectionEffect = new StealFuel(gameObject);
    }
    public override void TriggerEffect()
    {
        SelectNextPlayerOnTrigger();
        print("Steal another players fuel!");
    }

    private void Update()
    {
        if (gameObject.tag == TAG_SELECTION)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer(playersHandler.GetCurrentPlayer());
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
               selectionEffect.ConfirmedSelection();
            }
        }
    }
}
