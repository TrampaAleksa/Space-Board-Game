using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public float ScrollSpeed = 2;
    public float speed=0.01f;
    float Horizontal;
    float Vertical;
    Vector3 tmp;
    void Update()
    {
        Horizontal = Input.GetAxis("Mouse X")*0.01f;
        Vertical = Input.GetAxis("Mouse Y") * 0.01f;
        tmp += new Vector3(Horizontal, 0, Vertical);

        if (Input.mousePosition.y >= Screen.height * 0.99 || Input.mousePosition.y <= Screen.height * 0.01 || Input.mousePosition.x >= Screen.width * 0.99 || Input.mousePosition.x <= Screen.width * 0.01)
        {
            transform.position += tmp * Time.deltaTime * ScrollSpeed;
        }
    }
}
