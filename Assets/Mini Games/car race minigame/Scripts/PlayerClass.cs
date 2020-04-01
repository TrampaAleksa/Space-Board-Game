using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerClass
{
    private string nameOfInputHorizontal;
    private string nameOfInputVertical;
    private string nameOfRespawnButton;
    private GameObject body;
    private int element;
    private string nameOfPlayer;
    private float maxSteerAngle;
    private float motorForce;
    private float maximumRotation;
    private Text text;
    private WheelCollider[] wheelColliders;

    public PlayerClass(GameObject playerObject, int element, string name, float maxSteerAngle, float motorForce, float maximumRotation)
    {
        this.element = element;
        this.nameOfInputHorizontal = "Horizontal" + (element + 1);
        this.nameOfInputVertical = "Vertical" + (element + 1);
        this.nameOfRespawnButton = "Fire" + (element + 1);
        this.nameOfPlayer = name;
        this.maxSteerAngle = maxSteerAngle;
        this.motorForce = motorForce;
        this.maximumRotation = maximumRotation;
        this.wheelColliders = playerObject.GetComponentsInChildren<WheelCollider>();
        this.body=playerObject.GetComponentInChildren<MeshRenderer>().gameObject;
        GameObject[] tmpT = GameObject.FindGameObjectsWithTag("PlayerSpeed");
        Text[] tmpTxt = new Text[tmpT.Length];
        for (int i = 0; i < tmpT.Length; i++)
        {
            tmpTxt[i] = tmpT[i].GetComponent<Text>();
        }
        this.text = tmpTxt[element];
    }
    //methods
    public void Brake(float m_verticalInput)
    {
        if (wheelColliders[0].radius*wheelColliders[0].rpm > 1)
        {
            wheelColliders[0].motorTorque = wheelColliders[1].motorTorque = 0;
            wheelColliders[0].brakeTorque = wheelColliders[1].brakeTorque = -m_verticalInput * motorForce * 4;
        }
        if (wheelColliders[0].radius*wheelColliders[0].rpm <= 1)
        {
            SpeedUp(m_verticalInput);
        }
    }
    public void RotateBody(float m_horizontalInput)
    {
        body.transform.localEulerAngles= new Vector3(body.transform.rotation.x,body.transform.rotation.y,-maximumRotation*m_horizontalInput);
    }
    public void Steer(float m_horizontalInput)
    {
        wheelColliders[0].steerAngle = wheelColliders[1].steerAngle = maxSteerAngle * m_horizontalInput;
    }
    public void Accelerate(float m_verticalInput)
    {
        if(wheelColliders[0].isGrounded || wheelColliders[1].isGrounded)
            SpeedUp(m_verticalInput);
    }
    public void SpeedUp(float m_verticalInput)
    {
        wheelColliders[0].brakeTorque = wheelColliders[1].brakeTorque = 0;
        wheelColliders[0].motorTorque = wheelColliders[1].motorTorque = m_verticalInput * motorForce;
    }
    public void CountSpeed()
    {
        text.text= ((int)(wheelColliders[0].radius * wheelColliders[0].rpm)).ToString();
    }
    //prop
    public string NameOfInputHorizontal { get { return nameOfInputHorizontal; } set { nameOfInputHorizontal = value; } }
    public string NameOfInputVertical { get { return nameOfInputVertical; } set { nameOfInputVertical = value; } }
    public string NameOfRespawnButton { get { return nameOfRespawnButton; } set { nameOfRespawnButton = value; } }
    public Text Text { get { return text; } set { text = value; } }
    public int Element { get { return element; } set { element=value; } }
    public string NameOfPlayer { get { return nameOfPlayer; } set { nameOfPlayer = value; } }
    public float MaxSteerAngle { get { return maxSteerAngle; } set { maxSteerAngle = value; } }
    public float MotorForce { get { return motorForce; } set { motorForce = value; } }
    public float MaximumRotation { get { return maximumRotation; } set { maximumRotation = value; } }
    public WheelCollider[] WheelColliders { get { return wheelColliders; } set{ wheelColliders=value; } }
}