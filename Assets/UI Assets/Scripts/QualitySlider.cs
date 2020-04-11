using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class QualitySlider : SlideLeftRight
{
    public static QualitySlider Instance;  
    private void Awake() {
        Instance=this;
    }
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

    public override void ApplySettings()
    {
        priviousIndex=index;
        UIManager.Instance.SetQuiality(index);
    }

    public override void RevertSettings()
    {
        index=priviousIndex;
        RefreshShownValue();
        
    }
}