using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipTest : MonoBehaviour
{
    private Tooltip tooltip;

    private void Start()
    {
        tooltip = GameObject.FindGameObjectWithTag("Tooltip").GetComponent<Tooltip>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            tooltip.GetComponent<Animator>().SetTrigger(TooltipAnimationType.Trigger3Seconds.ToString());
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            tooltip.GetComponent<Animator>().SetTrigger(TooltipAnimationType.Trigger5Seconds.ToString());
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            tooltip.GetComponent<Animator>().SetTrigger(TooltipAnimationType.Trigger8Seconds.ToString());
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            tooltip.GetComponent<Animator>().SetTrigger(TooltipAnimationType.Trigger10Seconds.ToString());
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            tooltip.GetComponent<Animator>().SetTrigger(TooltipAnimationType.TriggerFloatUp.ToString());
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject.Find("Text (TMP)").GetComponent<Animator>().SetTrigger("TriggerMeshFloatUp");
        }
    }
}