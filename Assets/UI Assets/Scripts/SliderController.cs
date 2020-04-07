using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public int step=10;
    float value;
    Slider slider;
    public static SliderController Instance;
    private void Awake() {
        Instance=this;
    }
    private void Start() {
        slider=GetComponent<Slider>();
        value=slider.value;
    }
    public void PressedLeftButton()
    {
        if(value>slider.minValue)
            value-=step;
        ChangeValue();
    }
    public void PressedRightButton()
    {
        if(value<slider.maxValue)
            value+=step;
        ChangeValue();
    }
    private void ChangeValue()
    {
        slider.value=value;
    }
}
