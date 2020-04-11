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
        priviousIndex=index;
        UIManager.Instance.ApplyResolution(index);
    }
    public override void RevertSettings()
    {
        index=priviousIndex;
        RefreshShownValue();
    }
}
