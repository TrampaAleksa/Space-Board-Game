using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionSlide : SlideLeftRight
{
    public void OnApplyPress()
    {
        UIManager.Instance.SetResolution(index);
    }
}
