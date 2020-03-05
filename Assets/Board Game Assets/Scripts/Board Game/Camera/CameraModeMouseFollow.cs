using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModeMouseFollow : ICameraMode
{
    private const double UpperBoundary = 0.98f;
    public float ScrollSpeed = 2;
    public float speed = 0.2f;
    private float Horizontal;
    private float Vertical;
    private Vector3 tmp;
    private Camera camera;

    public void UpdateCamera(Vector3 offset, float smoothSpeed)
    {
        camera = Camera.main;
        Horizontal = Input.GetAxis("Mouse X") * speed;
        Vertical = Input.GetAxis("Mouse Y") * speed;
        tmp += new Vector3(Horizontal, 0, Vertical);

        if (Input.mousePosition.y >= Screen.height * UpperBoundary || Input.mousePosition.y <= Screen.height * (1f - UpperBoundary) || Input.mousePosition.x >= Screen.width * UpperBoundary || Input.mousePosition.x <= Screen.width * (1f - UpperBoundary))
        {
            camera.transform.parent.transform.position += tmp * Time.deltaTime * ScrollSpeed;
        }
    }
}