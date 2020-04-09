using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionSlide : SlideLeftRight
{
    public static ResolutionSlide Instance;  
    private void Awake() {
        Instance=this;
    }
    public override void ApplySettings()
    {
        UIManager.Instance.ApplyResolution(index);
    }
}
