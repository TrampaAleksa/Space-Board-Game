using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Lerping 
{
    public static void LerpObjectToPosition(Vector3 desiredPosition, GameObject objectToMove, float smoothSpeed)
    {
        Vector3 smoothedPosition = Vector3.Lerp(objectToMove.transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        objectToMove.transform.position = smoothedPosition;
    }

    public static void LerpObjectRotationToPosition(Vector3 targetPosition, GameObject objectToRotate, float rotationSpeed)
    {
        Vector3 _lookDirection = targetPosition - objectToRotate.transform.position;
        Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
        objectToRotate.transform.rotation = Quaternion.Lerp(objectToRotate.transform.rotation, _rot, rotationSpeed * Time.deltaTime);
    }
}
