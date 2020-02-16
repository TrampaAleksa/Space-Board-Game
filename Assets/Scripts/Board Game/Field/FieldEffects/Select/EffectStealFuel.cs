using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectStealFuel : FieldEffect
{
    public const float AMOUNT_TO_STEAL = 20f;
    private ISelectionEffect selectionEffect;

    private void Awake()
    {
        selectionEffect = new StealFuel(gameObject);
    }
    public override void TriggerEffect()
    {
        gameObject.tag = TAG_SELECTION;
        InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer(playersHandler.GetCurrentPlayer());
        print(playersHandler.GetCurrentPlayer().name + " Is now choosing: ");
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
