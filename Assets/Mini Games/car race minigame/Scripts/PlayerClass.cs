using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerClass
{
    private int element;
    private string name;
    private float maxSteerAngle;
    private float motorForce;
    private float maximumRotation;

    public PlayerClass(int element, string name, float maxSteerAngle, float motorForce,float maximumRotation)
    {
        this.element = element;
        this.name = name;
        this.maxSteerAngle=maxSteerAngle;
        this.motorForce=motorForce;
        this.maximumRotation=maximumRotation;

    }
    public int Element
    {
        get { return element; }
        set { element=value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public float MaxSteerAngle
    {
        get { return maxSteerAngle; }
        set { maxSteerAngle = value; }
    }

    public float MotorForce
    {
        get { return motorForce; }
        set { motorForce = value; }
    }
    public float MaximumRotation
    {
        get { return maximumRotation; }
        set { maximumRotation = value; }
    }
}
