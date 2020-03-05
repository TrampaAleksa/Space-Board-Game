﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMoveForward : FieldEffect
{
    public override void TriggerEffect()
    {
        GenericTriggerEffect();
        GameObject currentPlayer = playersHandler.GetCurrentPlayer();
        InstanceManager.Instance.Get<MovementHandler>().MoveNFields(1, currentPlayer);
    }
}