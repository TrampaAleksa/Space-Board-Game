using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipTest : MonoBehaviour
{
    private TextTooltip tooltip;
    private bool howeredOver;
    private FieldHowerTooltip howerTooltip;

    private void Start()
    {
        howeredOver = false;
        howerTooltip = GameObject.Find("Field hower holder").GetComponent<FieldHowerTooltip>();
        print(howerTooltip.name);
        tooltip = GameObject.FindGameObjectWithTag("Tooltip").GetComponent<TextTooltip>();
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
        if (Input.GetKeyDown(KeyCode.S))
        {
        }
        if (howeredOver)
        {
            howerTooltip.ShowTooltip("Floated over");
        }
        else
        {
            howerTooltip.RemoveTooltip();
        }
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Field")))
        {
            howerTooltip = hit.collider.gameObject.GetComponentInChildren<FieldHowerTooltip>();
            howeredOver = true;
            howerTooltip.transform.position = hit.transform.position + (Vector3.up * 3);
            Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
        }
        else
        {
            howeredOver = false;
        }
    }
}