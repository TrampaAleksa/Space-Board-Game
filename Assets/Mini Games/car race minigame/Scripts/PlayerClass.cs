using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerClass
{
    private string nameOfInputHorizontal;
    private string nameOfInputVertical;
    private GameObject playerObject;
    private GameObject bodyForRotate;
    private int element;
    private string nameOfPlayer;
    private float maxSteerAngle;
    private float motorForce;
    private float maximumRotation;
    private GameObject panel;
    private Text text;
    private WheelCollider[] wheelColliders;

    public PlayerClass(GameObject playerObject, int element, string name, float maxSteerAngle, float motorForce, float maximumRotation)
    {
        this.element = element;
        this.nameOfInputHorizontal = "Horizontal" + (element + 1);
        this.nameOfInputVertical = "Vertical" + (element + 1);
        this.nameOfPlayer = name;
        this.maxSteerAngle = maxSteerAngle;
        this.motorForce = motorForce;
        this.maximumRotation = maximumRotation;
        this.playerObject = playerObject;
        this.bodyForRotate = playerObject.GetComponentInChildren<ROTATEBODY>().gameObject;
        this.wheelColliders = playerObject.GetComponentsInChildren<WheelCollider>();
        GameObject[] tmpP = GameObject.FindGameObjectsWithTag("PPanel");
        Panel = tmpP[0];
        GameObject[] tmpT = GameObject.FindGameObjectsWithTag("PText");
        Text[] tmpTxt = new Text[tmpT.Length];
        for (int i = 0; i < tmpT.Length; i++)
        {
            tmpTxt[i] = tmpT[i].GetComponent<Text>();
        }
        this.text = tmpTxt[element];
    }
    //methods
    public void Rotation(float m_horizontalInput)
    {
        bodyForRotate.transform.localEulerAngles = new Vector3(0, -(m_horizontalInput * maximumRotation), 0);
    }
    public void Brake(float m_verticalInput)
    {
        if (((int)(wheelColliders[0].radius * wheelColliders[0].rpm) / 2) > 0)
        {
            wheelColliders[0].motorTorque = wheelColliders[1].motorTorque = 0;
            wheelColliders[0].brakeTorque = wheelColliders[1].brakeTorque = -m_verticalInput * motorForce * 2;
        }
        if (((int)(wheelColliders[0].radius * wheelColliders[0].rpm) / 2) <= 0)
        {
            SpeedUp(m_verticalInput);
        }
    }
    public void Steer(float m_horizontalInput)
    {
        Debug.Log(wheelColliders[0].motorTorque);
        wheelColliders[0].steerAngle = wheelColliders[1].steerAngle = maxSteerAngle * m_horizontalInput;
    }
    public void Accelerate(float m_verticalInput)
    {
        SpeedUp(m_verticalInput);
    }
    public void SpeedUp(float m_verticalInput)
    {
        wheelColliders[0].brakeTorque = wheelColliders[1].brakeTorque = 0;
        wheelColliders[0].motorTorque = wheelColliders[1].motorTorque = m_verticalInput * motorForce;
    }
    public void CountSpeed()
    {
        text.text= ((int)(wheelColliders[0].radius * wheelColliders[0].rpm)/2).ToString();
    }
    //prop
    public string NameOfInputHorizontal { get { return nameOfInputHorizontal; } set { nameOfInputHorizontal = value; } }
    public string NameOfInputVertical { get { return nameOfInputVertical; } set { nameOfInputVertical = value; } }
    public GameObject PlayerObject { get { return playerObject; } set { playerObject=value; } }
    public Text Text { get { return text; } set { text = value; } }
    public GameObject Panel { get { return panel; } set => panel = value; }
    public int Element { get { return element; } set { element=value; } }
    public string Name { get { return nameOfPlayer; } set { nameOfPlayer = value; } }
    public float MaxSteerAngle { get { return maxSteerAngle; } set { maxSteerAngle = value; } }
    public float MotorForce { get { return motorForce; } set { motorForce = value; } }
    public float MaximumRotation { get { return maximumRotation; } set { maximumRotation = value; } }
    public WheelCollider[] WheelColliders { get { return wheelColliders; } set{ wheelColliders=value; } }
}