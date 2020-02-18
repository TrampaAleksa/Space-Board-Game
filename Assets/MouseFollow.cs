using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public float ScrollSpeed=15;
    float Horizontal;
    float Vertical;

    void Update()
    {
        Horizontal=Input.GetAxis("Mouse X");
        Vertical=Input.GetAxis("Mouse Y");

        if(Input.mousePosition.y>=Screen.height * 0.95)
        {
            transform.Translate(new Vector3(Horizontal,0,Vertical)*Time.deltaTime*ScrollSpeed,Space.World);
        }
    }
}
