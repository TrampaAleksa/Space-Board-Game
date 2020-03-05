using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLockEnemy : SelectOnTrigger
{
    public const int TURNS_TO_LOCK = 1;

    public override void TriggerEffect()
    {
        SelectNextPlayerOnTrigger();
        GenericTriggerEffect();
        print("Break another players engines!");
    }

    private void Awake()
    {
        selectionEffect = new LockEnemy(gameObject);
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