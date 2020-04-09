using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public abstract class SlideLeftRight : MonoBehaviour
{
    public int index;
    public List<string> labelList=new List<string>();
    public Text label;
    abstract public void ApplySettings();
    private void Start() {
        label=gameObject.GetComponentInChildren<Text>();
    }
    public void AddOptions(List<string> labels)
    {
        labelList.AddRange(labels);
    }
    public void RefreshShownValue()
    {
        label.text=labelList[index];
    }
    public void PressedLeftButton()
    {
        index--;
        if(index<0)
            index=labelList.Count-1;
        RefreshShownValue();
    }
    public void PressedRightButton()
    {
        index++;
        if(index>labelList.Count-1)
            index=0;
        RefreshShownValue();
    }
}
