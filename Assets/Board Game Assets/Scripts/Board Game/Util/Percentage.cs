using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Percentage 
{
    public static float ScaleToPercentages(float maximumValue, float valueToScale)
    {
        return (valueToScale / maximumValue) * 100f;
    }

    public static float ScaleFromPercentage(float maximumValue, float percentageValue)
    {
        return (maximumValue / 100f) * percentageValue;
    }
}
