using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class SlideLeftRight : MonoBehaviour
{
    public int index=0;
    public List<string> labelList=new List<string>();
    public Text label;
    public static SlideLeftRight Instance;
    private void Awake() {
        Instance=this;
    }
    private void Start() {
        label=gameObject.GetComponentInChildren<Text>();
    }
    public void AddOptions(List<string> label)
    {
        labelList.AddRange(label);
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
