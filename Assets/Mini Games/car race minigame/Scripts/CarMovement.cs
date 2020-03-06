using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private float m_horizontalInput;
    private float m_verticalInput;
    public static CarMovement Instance;
    private void Awake()
    {
        Instance=this;
    }
    public void Move(WheelCollider frontRightW, WheelCollider frontLeftW, WheelCollider rearLeftW, WheelCollider rearRightW, float motorForce, float maxSteerAngle, float maximumRotation, Transform BodyForRotate, string nameOfInputHorizontal, string nameOfInputVertical)
    {
        GetInput(nameOfInputHorizontal, nameOfInputVertical);
        Steer(frontRightW, frontLeftW, maxSteerAngle);
        Rotation(BodyForRotate, maximumRotation);
        if(m_verticalInput<0)
            Break(frontRightW, frontLeftW, motorForce);
        else    Accelerate(frontRightW, frontLeftW, rearLeftW, rearRightW, motorForce);
    }

    public void GetInput(string nameOfInputHorizontal, string nameOfInputVertical)
    {
        m_horizontalInput = Input.GetAxis(nameOfInputHorizontal);
        m_verticalInput = Input.GetAxis(nameOfInputVertical);
    }

    public void Rotation(Transform BodyForRotate, float maximumRotation)
    {
        BodyForRotate.transform.localRotation = new Quaternion(0,-(m_horizontalInput* maximumRotation), 0, 180);
    }

    public void Break(WheelCollider frontRightW, WheelCollider frontLeftW, float motorForce)
    {
        frontRightW.motorTorque = frontLeftW.motorTorque = m_verticalInput * motorForce*2;
    }

    public void Steer(WheelCollider frontRightW, WheelCollider frontLeftW, float maxSteerAngle)
    {
        frontRightW.steerAngle = frontLeftW.steerAngle = maxSteerAngle * m_horizontalInput;
    }

    public void Accelerate(WheelCollider frontRightW, WheelCollider frontLeftW, WheelCollider rearLeftW, WheelCollider rearRightW, float motorForce)
    {
        frontRightW.motorTorque = frontLeftW.motorTorque = rearLeftW.motorTorque=rearRightW.motorTorque = m_verticalInput * motorForce;
    }
}
