using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipTest : MonoBehaviour
{
    private Tooltip tooltip;
    void Start()
    {
        tooltip = GameObject.FindGameObjectWithTag("Tooltip").GetComponent<Tooltip>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            tooltip.GetComponent<Animator>().SetTrigger("Trigger3Seconds");
        }
    }
}
