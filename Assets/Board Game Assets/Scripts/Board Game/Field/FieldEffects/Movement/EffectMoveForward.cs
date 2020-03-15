using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMoveForward : FieldEffect
{
    public override void FinishedEffect()
    {
        throw new System.NotImplementedException();
    }

    public override void TriggerEffect()
    {
        GenericTriggerEffect();
        GameObject currentPlayer = playersHandler.GetCurrentPlayer();
        int fieldsToMove = Random.Range(1, 7);
        InstanceManager.Instance.Get<TooltipHandler>().ShowPlayersTooltip(currentPlayer, "+" + fieldsToMove + " fields");
        InstanceManager.Instance.Get<MovementHandler>().MoveNFields(fieldsToMove, currentPlayer);
    }
}