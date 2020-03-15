using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMoveForward : FieldEffect, IGenericFieldEffect
{
    public override void FinishedEffect()
    {
    }

    public override void TriggerEffect()
    {
        GameObject currentPlayer = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer();
        int fieldsToMove = Random.Range(1, 7);
        InstanceManager.Instance.Get<TooltipHandler>().ShowPlayersTooltip(currentPlayer, "+" + fieldsToMove + " fields");
        InstanceManager.Instance.Get<MovementHandler>().MoveNFields(fieldsToMove, currentPlayer);
        InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(gameObject);
    }
}