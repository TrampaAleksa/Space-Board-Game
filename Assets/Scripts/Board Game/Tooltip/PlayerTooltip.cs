using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTooltip : MonoBehaviour
{
    [SerializeField]
    public Tooltip tooltip;
    public GameObject tooltipText;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //tooltip = tooltipText.GetComponentInChildren<Tooltip>();
    }

    // Update is called once per frame
    void Update()
    {
        tooltipText.transform.position = transform.position + offset;
    }
}
