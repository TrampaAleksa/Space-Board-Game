using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTooltip : MonoBehaviour
{
    [SerializeField]
    public TextMeshTooltip tooltip;

    private GameObject tooltipText;
    public Vector3 offset;

    // Start is called before the first frame update
    private void Start()
    {
        tooltipText = tooltip.gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        tooltipText.transform.position = transform.position + offset;
    }
}