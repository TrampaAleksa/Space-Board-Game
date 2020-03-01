using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public partial class PlayerController : MonoBehaviour
{
    private int lap;
    private bool beforeFinishPass = false;
    private bool playerFinishRace = false;
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;
    private int num;

    private Text[] pText;
    public string nameOfInputHorizontal;
    public string nameOfInputVertical;

    public WheelCollider frontLeftW, frontRightW,
                         rearLeftW, rearRightW;

    public float maxSteerAngle;
    public float motorForce;
    public float numberOfLaps;

    public static PlayerController Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        WheelCollider[] wheelColliders = gameObject.GetComponentsInChildren<WheelCollider>();
        for (int i = 0; i < 4; i++)
        {
            if (wheelColliders[i].name == "WC_FRONTLEFT")
                frontLeftW = wheelColliders[i];
            else if (wheelColliders[i].name == "WC_FRONTRIGHT")
                frontRightW = wheelColliders[i];
            else if (wheelColliders[i].name == "WC_REARLEFT")
                rearLeftW = wheelColliders[i];
            else if (wheelColliders[i].name == "WC_REARRIGHT")
                rearRightW = wheelColliders[i];
        }
        pText = GameObject.Find("Canvas").GetComponentsInChildren<Text>();
        num = int.Parse(gameObject.name);
        pText[num - 1].text = "Lap: " + lap.ToString() + "/" + numberOfLaps;
    }

    private void FixedUpdate()
    {
        if (!playerFinishRace)
        {
            GetInput();
            Steer();
            Accelerate();
        }
    }

    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis(nameOfInputHorizontal);
        m_verticalInput = Input.GetAxis(nameOfInputVertical); //Podesavanje osa za strelice
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput; //Ugao od pritiska strelice
        frontRightW.steerAngle = frontLeftW.steerAngle = m_steeringAngle; //Prednji levi tocak
    }

    public void Accelerate()
    {
        frontRightW.motorTorque = frontLeftW.motorTorque = m_verticalInput * motorForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            if (numberOfLaps != lap)
            {
                if (!beforeFinishPass)
                {
                    FinishedLap();
                }
            }
            else
            {
                playerFinishRace = true;
                GameManager.Instance.PlayerFinishRace(gameObject.name);
                FinishedLap();
            }
        }
        if (other.tag == "Death")
        {
            Debug.Log("Died");
        }

        if (other.tag == "NextField")
        {
            beforeFinishPass = false;
        }
    }

    private void FinishedLap()
    {
        lap++;
        pText[num - 1].text = "Lap: " + (lap - 1).ToString() + "/" + numberOfLaps;
        beforeFinishPass = true;
    }
}