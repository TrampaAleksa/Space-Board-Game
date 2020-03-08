using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipHowerPivotInit : MonoBehaviour
{
    public GameObject pivot;

    private void Awake()
    {
        GameObject[] fields = GameObject.FindGameObjectsWithTag("Field");
        foreach (var field in fields)
        {
            Instantiate(pivot, field.transform.position, pivot.transform.rotation, field.transform);
        }
    }
}