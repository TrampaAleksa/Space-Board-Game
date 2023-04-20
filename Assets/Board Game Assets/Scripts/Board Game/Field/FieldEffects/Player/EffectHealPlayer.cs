using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHealPlayer : FieldEffect, IGenericFieldEffect
{
    public float amountToHeal => GameConfig.GetConfig<HealthConfig>().healthOnRepair;

    public override void TriggerEffect()
    {
        Repair.RepairPlayer(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer(), amountToHeal, HullHandler.maximumHull); //TODO - Pass in player hull instance instead of values
        InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(gameObject);
    }

    public override void FinishedEffect()
    {
        DisplayInActivityHistory();
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }

    private void DisplayInActivityHistory()
    {
        new ATPlayerHealed(
            InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer(),
            (int)amountToHeal
        ).DisplayAT();
    }
}