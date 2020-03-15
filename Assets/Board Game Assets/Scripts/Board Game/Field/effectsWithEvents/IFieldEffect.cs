using System;

public interface IFieldEffect
{
    Action TriggerEffect();
    Action FinishedEffect();
}