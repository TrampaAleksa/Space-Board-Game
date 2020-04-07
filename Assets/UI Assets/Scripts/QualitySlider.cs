using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualitySlider : SlideLeftRight
{
    private void Start() {
        List<string> tmp=new List<string>();
        tmp.Add("VERY LOW");
        tmp.Add("LOW");
        tmp.Add("MEDIUM");
        tmp.Add("HIGH");
        tmp.Add("VERYHIGH");
        tmp.Add("ULTRA");
        AddOptions(tmp);
        RefreshShownValue();
    }
    public void OnApplyPress()
    {
        UIManager.Instance.SetResolution(index);
    }
}
