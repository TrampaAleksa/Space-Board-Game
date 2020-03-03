using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITooltipAction 

{
    void ShowTooltip(TooltipAnimationType type, string message);
    void ShowTooltip(string message);
}
