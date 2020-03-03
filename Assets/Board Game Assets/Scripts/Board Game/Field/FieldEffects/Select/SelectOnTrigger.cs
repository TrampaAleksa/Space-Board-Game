using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectOnTrigger : FieldEffect
{
    public void SelectNextPlayerOnTrigger()
    {
        gameObject.tag = TAG_SELECTION;
        InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer(playersHandler.GetCurrentPlayer());
        print(playersHandler.GetCurrentPlayer().name + " Is now choosing: ");
    }
}
